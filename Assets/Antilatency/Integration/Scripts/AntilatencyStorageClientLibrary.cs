using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Antilatency.Integration {
    /// <summary>
    /// %Antilatency Storage Client provider. Allows you to communicate with AltSystem storage: gets/sets default environment/placement, etc.
    /// </summary>
    public class AntilatencyStorageClientLibrary {
        /// <summary>
        /// Get storage singleton. 
        /// </summary>
        public static AntilatencyStorageClientLibrary Storage {
            get {
                if (_storageInstance == null) {
                    _storageInstance = new AntilatencyStorageClientLibrary();
                }
                return _storageInstance;
            }
        }

        private static AntilatencyStorageClientLibrary _storageInstance = null;

        private AntilatencyStorageClient.ILibrary _library;
        private AntilatencyStorageClient.IStorage _storage;

        private AntilatencyStorageClientLibrary() {
            _library = AntilatencyStorageClient.Library.load();
            if (_library == null) {
                Debug.LogError("Failed to load AltSystemClient library");
                return;
            }

#if UNITY_ANDROID && !UNITY_EDITOR
            var jni = _library.QueryInterface<AndroidJniWrapper.IAndroidJni>();
            using (var player = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
                using (var activity = player.GetStatic<AndroidJavaObject>("currentActivity")) {
                    jni.initJni(IntPtr.Zero, activity.GetRawObject());
                }
            }
            jni.Dispose();
#endif

            _storage = _library.getLocalStorage();
            if (_storage == null) {
                Debug.LogError("Failed to get AltSystemClient local storage");
                return;
            }

#if UNITY_EDITOR
            EditorApplication.playModeStateChanged += OnEditorStateChanged;
#endif
            _library.Dispose();
            _library = null;
        }

        /// <summary>
        /// Get placement code by name.
        /// </summary>
        /// <param name="placementName">Placement name. If not used, default placement will be return.</param>
        /// <returns>Placement code string.</returns>
        public string GetPlacementCode(string placementName = "default") {
            if (_storage == null) {
                return null;
            }
            return _storage.read("placement", placementName);
        }

        /// <summary>
        /// Get environment code by name.
        /// </summary>
        /// <param name="environmentName">Environment name. If not used, default environment will be return.</param>
        /// <returns>Environment code string.</returns>
        public string GetEnvironmentCode(string environmentName = "default") {
            if (_storage == null) {
                return null;
            }
            return _storage.read("environment", environmentName);
        }

        /// <summary>
        /// Save placement to AltSystem app.
        /// </summary>
        /// <param name="name">Placement name.</param>
        /// <param name="code">Placement code.</param>
        public void SavePlacementToAltSystem(string name, string code) {
            if (_storage == null) {
                return;
            }
            _storage.write("placement", name, code);
        }

        /// <summary>
        /// Save environment to AltSystem app.
        /// </summary>
        /// <param name="name">Environment name.</param>
        /// <param name="code">Environment code.</param>
        public void SaveEnvironmentToAltSystem(string name, string code) {
            if (_storage == null) {
                return;
            }
            _storage.write("environment", name, code);
        }

        /// <summary>
        /// Set placement as default in AltSystem.
        /// </summary>
        /// <param name="name">Placement name.</param>
        public void SetDefaultPlacement(string name) {
            if (_storage == null) {
                return;
            }
            _storage.write("placement", ".default", name);
        }

        /// <summary>
        /// Set environment as default in AltSystem.
        /// </summary>
        /// <param name="name">Environment name.</param>
        public void SetDefaultEnvironment(string name) {
            if (_storage == null) {
                return;
            }
            _storage.write("environment", ".default", name);
        }

#if UNITY_EDITOR
        private static void OnEditorStateChanged(PlayModeStateChange state) {
            if (state == PlayModeStateChange.EnteredEditMode) {
                Debug.Log("Unload factory");

                if (_storageInstance == null) {
                    return;
                }

                if (_storageInstance._storage != null) {
                    _storageInstance._storage.Dispose();
                    _storageInstance._storage = null;
                }

                if (_storageInstance._library != null) {
                    _storageInstance._library.Dispose();
                    _storageInstance._library = null;
                }
            }
        }
#endif
    }
}