using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

namespace Antilatency.Integration {
    [CustomEditor(typeof(AltEnvironment))]
    public class AltEnvironmentCustomEditor : Editor {
        private SerializedProperty _drawBars;
        private SerializedProperty _drawContours;
        private SerializedProperty _contoursTarget;
        private SerializedProperty _enableContourOffset;
        private SerializedProperty _contourOffset;
        private SerializedProperty _useCustomContours;
        private SerializedProperty _customContours;

        private GUIStyle _headerStyle;

        private void OnEnable() {
            _drawBars = serializedObject.FindProperty("DrawBars");
            _drawContours = serializedObject.FindProperty("DrawContours");
            _contoursTarget = serializedObject.FindProperty("ContoursTarget");
            _enableContourOffset = serializedObject.FindProperty("EnableContourOffset");
            _contourOffset = serializedObject.FindProperty("ContourOffset");
            _useCustomContours = serializedObject.FindProperty("UseCustomContours");
            _customContours = serializedObject.FindProperty("CustomContours");
        }

        private void InitStyles() {
            _headerStyle = new GUIStyle(GUI.skin.label);
            _headerStyle.fontStyle = FontStyle.Bold;
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();

            if (_headerStyle == null) {
                InitStyles();
            }

            GUILayout.Label("General settings", _headerStyle);

            EditorGUILayout.PropertyField(_drawBars);
            EditorGUILayout.PropertyField(_drawContours);

            if (_drawContours.boolValue) {
                GUILayout.Space(10);
                GUILayout.Label("Contours settings", _headerStyle);
                GUILayout.Label("Currently only custom contours are supported", _headerStyle);

                EditorGUILayout.PropertyField(_contoursTarget);
                EditorGUILayout.PropertyField(_enableContourOffset);
                if (_enableContourOffset.boolValue) {
                    EditorGUILayout.PropertyField(_contourOffset);
                }

                EditorGUILayout.PropertyField(_useCustomContours);
                if (_useCustomContours.boolValue) {
                    EditorGUILayout.PropertyField(_customContours, true);
                    
                }
            }
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}