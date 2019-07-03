using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Antilatency.DeviceNetwork;

namespace Antilatency.Integration {
    /// <summary>
    /// Provides Device Network change control mechanics.
    /// </summary>
    public class FactoryObserver {
        private int LastNumChanges;
        private IFactory _factory;

        /// <summary>
        /// FactoryObserver default constructor.
        /// </summary>
        /// <param name="NumChanges"></param>
        public FactoryObserver(int NumChanges = -1) {
            Debug.Log("FactoryObserver init");
            LastNumChanges = NumChanges;
            _factory = DeviceNetworkFactoryProvider.Factory;
        }

        /// <summary>
        /// Check if Device Network has been changed since last check.
        /// </summary>
        /// <returns>True if Device Network has been changed, otherwise false.</returns>
        public bool Changed() {
            if (_factory == null) {
                Debug.LogError("Factory is null");
                return false;
            }

            int CurrentNumChanges = (int)_factory.getUpdateId();
            if (CurrentNumChanges != LastNumChanges) {
                LastNumChanges = CurrentNumChanges;
                Debug.Log("Factory update: " + CurrentNumChanges);
                return true;
            }
            return false;
        }
    }
}