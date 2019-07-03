using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Antilatency.Integration {
    /// <summary>
    /// Basic %Antilatency ALT tracking implementation, searches the first free ALT tracker and starts tracking task. Pose will be applied to gameobject with that component.
    /// </summary>
    public class AltTrackingDirect : AltTracking {
        protected override void Update() {
            base.Update();

            Antilatency.Alt.Tracking.State trackingState;

            if (!GetTrackingState(out trackingState)) {
                return;
            }

            transform.localPosition = trackingState.pose.position;
            transform.localRotation = trackingState.pose.rotation;
        }
    }
}

