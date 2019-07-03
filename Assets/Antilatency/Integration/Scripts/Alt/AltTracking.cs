using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Events;

using Antilatency.DeviceNetwork;

namespace Antilatency.Integration {
    /// <summary>
    /// Provides base tracking functionality.
    /// </summary>
    public abstract class AltTracking : MonoBehaviour {
        [Serializable]
        public class BoolEvent : UnityEvent<bool> { }

        /// <summary>
        /// Link to AltEnvironment component
        /// </summary>
        public AltEnvironment Environment;

        /// <summary>
        /// Pose prediction time.
        /// </summary>
        public float ExtrapolationTime = .03f;

        /// <summary>
        /// This event will be invoked every time when tracking task starts or stops, sending true on start and false on stop.
        /// </summary>
        public BoolEvent TrackingTaskStateChanged = new BoolEvent();

        /// <summary>
        /// Is tracking task is started
        /// </summary>
        public bool TrackingTaskState {
            get {
                return _trackingTask != null;
            }
        }

        protected Alt.Tracking.ILibrary _trackingLibrary;

        protected IFactory _factory;

        /// <summary>
        /// ALT tracker to center eye offset.
        /// </summary>
        protected UnityEngine.Pose _placement;

        /// <summary>
        /// Current tracking node (ALT tracker device).
        /// </summary>
        protected NodeHandle _trackingNode = Antilatency.DeviceNetwork.Constants.InvalidNode;

        private FactoryObserver _observer;
        private Alt.Tracking.ITask _trackingTask;
        
        private void Init() {
            _factory = DeviceNetworkFactoryProvider.Factory;
            _observer = new FactoryObserver();
        }

        private void StartTracking(NodeHandle node) {
            if (_factory == null) {
                Debug.LogError("Factory is null");
                return;
            }

            if (_factory.nodeGetStatus(node) != NodeStatus.Idle) {
                Debug.LogError("Wrong node status");
                return;
            }

            if (Environment == null || Environment.Environment == null) {
                Debug.LogError("Environment is null");
                return;
            }

            _trackingLibrary = Antilatency.Alt.Tracking.Library.load();

            _placement = GetPlacement();
            
            _trackingTask = _trackingLibrary.createTracking(_factory, node, Environment.Environment);
            _trackingNode = node;

            TrackingTaskStateChanged.Invoke(true);
        }

        /// <summary>
        /// Get placement from AltSystem app.
        /// </summary>
        /// <returns>Currently selected placement in AltSystem app.</returns>
        protected virtual Pose GetPlacement() {
            var result = Pose.identity;

            var altSystemClientLibrary = AntilatencyStorageClientLibrary.Storage;
            if (altSystemClientLibrary == null) {
                Debug.LogError("AltSystemClientLibrary is null");
                return result;
            }

            var placementCode = altSystemClientLibrary.GetPlacementCode();

            if (string.IsNullOrEmpty(placementCode)) {
                Debug.LogError("Failed to get placement code");
                result = Pose.identity;
            } else {
                result = _trackingLibrary.createPlacement(placementCode);
            }

            return result;
        }

        /// <summary>
        /// Get current raw tracking state without extrapolation and placement correction applied.
        /// </summary>
        /// <param name="state"> [out] result tracking state.</param>
        /// <returns>True if tracking is running, otherwise false.</returns>
        protected bool GetRawTrackingState(out Antilatency.Alt.Tracking.State state) {
            state = new Antilatency.Alt.Tracking.State();
            if (_trackingTask == null) {
                return false;
            }

            state = _trackingTask.getState();
            return true;
        }

        /// <summary>
        /// Get tracking state extrapolated and corrected by placement pose.
        /// </summary>
        /// <param name="state"> [out] result tracking state.</param>
        /// <returns>True if tracking is running, otherwise false.</returns>
        protected bool GetTrackingState(out Antilatency.Alt.Tracking.State state) {
            state = new Antilatency.Alt.Tracking.State();
            if (_trackingTask == null) {
                return false;
            }

            state = _trackingTask.getExtrapolatedState(_placement, ExtrapolationTime);
            return true;
        }

        private void StopTracking() {
            if (_trackingTask != null) {
                _trackingTask.Dispose();
                _trackingTask = null;
            }
            _trackingNode = Antilatency.DeviceNetwork.Constants.InvalidNode;

            TrackingTaskStateChanged.Invoke(false);
        }

        /// <summary>
        /// Get node (ALT tracker device) to start tracking task.
        /// </summary>
        /// <returns>First idle ALT tracker.</returns>
        protected virtual NodeHandle GetAvailableTrackingNode() {
            var nodes = _factory.getNodes().Where(v => _factory.nodeIsInterfaceSupported(v, Antilatency.Alt.Tracking.Constants.TaskID) && _factory.nodeGetStatus (v) == NodeStatus.Idle).ToArray();
            if (nodes.Length == 0) {
                return Antilatency.DeviceNetwork.Constants.InvalidNode;
            }

            return nodes[0];
        }

        /// <summary>
        /// Used for system initialization. When you override this method in derived class, remember to call basic class method first. 
        /// </summary>
        protected virtual void Awake() {
            Init();
        }

        /// <summary>
        /// Used for searching tracking nodes when no node is used for tracking otherwise checks node status to make some cleanup if node becomes invalid (device removed, etc.).
        /// When you override this method in derived class, remember to call basic class method first. 
        /// </summary>
        protected virtual void Update() {
            if (_observer.Changed() && _trackingTask == null) {
                var node = GetAvailableTrackingNode();
                if (node.value != Antilatency.DeviceNetwork.Constants.InvalidNode.value) {
                    StartTracking(node);
                }
            }

            if (_trackingTask != null && _trackingTask.isTaskFinished()) {
                StopTracking();
                return;
            }
        }

        /// <summary>
        /// Cleanup at component destroy. When you override this method in derived class, remember to call basic class method first. 
        /// </summary>
        protected virtual void OnDestroy() {
            if (_trackingTask != null) {
                _trackingTask.Dispose();
                _trackingTask = null;
            }

            if (_trackingLibrary != null) {
                _trackingLibrary.Dispose();
                _trackingLibrary = null;
            }
        }
    }
}