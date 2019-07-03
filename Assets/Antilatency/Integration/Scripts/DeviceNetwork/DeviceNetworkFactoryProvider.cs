using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Antilatency.DeviceNetwork;
using AntilatencyInterfaceContract;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Antilatency.Integration {
    /// <summary>
    /// %Antilatency Device Network factory provider.
    /// </summary>
    public class DeviceNetworkFactoryProvider {
        /// <summary>
        /// Get factory interface singleton. 
        /// </summary>
        public static IFactory Factory {
            get {
                if (_factoryProviderInstance == null) {
                    _factoryProviderInstance = new DeviceNetworkFactoryProvider();
                }

                return _factoryProviderInstance._factory;
            }
            private set { }
        }

        /// <summary>
        /// Default USB device type for work with %Antilatency devices.
        /// </summary>
        public static readonly UsbDeviceType AntilatencyDeviceType = new UsbDeviceType { vid = 0x0301, pid = 0x0000 };

        /// <summary>
        /// Array of device types to work with %Antilatency Device Network. By default consist of only #AntilatencyDeviceType.
        /// If you want to change that, set that field with corresponding types <b>BEFORE</b> #Factory property call.
        /// </summary>
        public static UsbDeviceType[] SupportedDeviceTypes {
            get {
                return _supportedDeviceTypes;
            }
            set {
                if (_factoryProviderInstance != null) {
                    Debug.LogWarning("Cannot set SupportedDeviceTypes when factory already initialized.");
                    return;
                }

                _supportedDeviceTypes = value;
            }
        }

        private static UsbDeviceType[] _supportedDeviceTypes = new UsbDeviceType[] { AntilatencyDeviceType };
        private static DeviceNetworkFactoryProvider _factoryProviderInstance = null;
        private ILibrary _library;
        private IFactory _factory;

        private DeviceNetworkFactoryProvider() {
            _library = Antilatency.DeviceNetwork.Library.load();
#if UNITY_ANDROID && !UNITY_EDITOR
            var jni = _library.QueryInterface<AndroidJniWrapper.IAndroidJni>();
            using (var player = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
                using (var activity = player.GetStatic<AndroidJavaObject>("currentActivity")) {
                    jni.initJni(IntPtr.Zero, activity.GetRawObject());
                }
            }
            jni.Dispose();
#endif
            _library.setLogLevel(LogLevel.Info);
            _factory = _library.createFactory(SupportedDeviceTypes);

#if UNITY_EDITOR
            EditorApplication.playModeStateChanged += OnEditorStateChanged;
#endif
        }

        /// <summary>
        /// Destroy factory interface singleton. Make sure that there is no references to it before calling this method.
        /// </summary>
        public static void DisposeFactory() {
            if (_factoryProviderInstance == null) {
                return;
            }

            if (_factoryProviderInstance._factory != null) {
                _factoryProviderInstance._factory.Dispose();
                _factoryProviderInstance._factory = null;
            }

            if (_factoryProviderInstance._library != null) {
                _factoryProviderInstance._library.Dispose();
                _factoryProviderInstance._library = null;
            }
        }

#if UNITY_EDITOR
        private static void OnEditorStateChanged(PlayModeStateChange state) {
            if (state == PlayModeStateChange.EnteredEditMode) {
                DisposeFactory();
            }
        }
#endif
    }
}