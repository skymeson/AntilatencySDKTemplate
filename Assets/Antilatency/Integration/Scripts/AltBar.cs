using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Antilatency.Integration {
    /// <summary>
    /// Represents %Antilatency reference bar with active IR markers. Used only for graphics purpose, quite useful at application debug.
    /// </summary>
    public struct AltBar {
        /// <summary>
        /// Markers position array.
        /// </summary>
        public Vector3[] Markers;

        private static float _width = 0.01f;
        private static float _markerRadius = 0.02f;
        private static float _markerOffset = 0.005f;
        private static int _markerSegmentsCount = 4;

        public AltBar(Vector3[] markers) {
            Markers = markers;
        }

        public AltBar(Vector3 markerA, Vector3 markerB, Vector3 markerC) {
            Markers = new Vector3[3] { markerA, markerB, markerC };
        }

        /// <summary>
        /// Get bar center point coordinate.
        /// </summary>
        public Vector3 GetPosition() {
            if (Markers.Length != 3) {
                Debug.LogWarning("Wrong markers count in bar");
                return Vector3.zero;
            }
            return Markers[0] + (Markers[2] - Markers[0]) / 2;
        }

        /// <summary>
        /// Get bar rotation.
        /// </summary>
        public Quaternion GetRotation() {
            if (Markers.Length != 3) {
                Debug.LogWarning("Wrong markers count in bar");
                return Quaternion.identity;
            }

            var direction = (Markers[2] - Markers[0]).normalized;
            return Quaternion.FromToRotation(Vector3.right, direction);
        }

        /// <summary>
        /// Get bar mesh.
        /// </summary>
        public Mesh GetMesh() {
            if (Markers.Length != 3) {
                return null;
            }

            var mesh = new Mesh();

            mesh.name = "Bar";

            var markerVerticesCount = _markerSegmentsCount + 1;

            var vertices = new Vector3[4 + markerVerticesCount * 3];
            var uv = new Vector2[vertices.Length];
            var markersTriangles = new int[_markerSegmentsCount * 3 * 3];

            for (var i = 0; i < Markers.Length; ++i) {
                var markerLocalPos = Quaternion.Inverse(GetRotation()) * (Markers[i] - GetPosition());

                Vector3[] markerVertices;
                Vector2[] markerUv;
                int[] markerTriangles;

                GetMarker(markerLocalPos, out markerVertices, out markerUv, out markerTriangles);

                for (var j = 0; j < markerVertices.Length; ++j) {
                    vertices[i * markerVerticesCount + j] = markerVertices[j];
                    uv[i * markerVerticesCount + j] = markerUv[j];
                }

                for (var j = 0; j < markerTriangles.Length; ++j) {
                    markersTriangles[i * _markerSegmentsCount * 3 + j] = markerTriangles[j] + i * markerVerticesCount;
                }
            }

            Vector3[] barVertices;
            Vector2[] barUv;
            int[] barTriangles;

            var barLength = (Markers[2] - Markers[0]).magnitude;

            GetBar(barLength, _width, out barVertices, out barUv, out barTriangles);

            for (var i = 0; i < barVertices.Length; ++i) {
                vertices[vertices.Length - barVertices.Length + i] = barVertices[i];
                uv[uv.Length - barUv.Length + i] = barUv[i];
            }

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.subMeshCount = 2;

            mesh.SetTriangles(barTriangles, 0, true, Markers.Length * markerVerticesCount);
            mesh.SetTriangles(markersTriangles, 1);

            return mesh;
        }

        private void GetMarker(Vector3 center, out Vector3[] vertices, out Vector2[] uv, out int[] triangles) {
            vertices = new Vector3[_markerSegmentsCount + 1];
            uv = new Vector2[vertices.Length];
            triangles = new int[_markerSegmentsCount * 3];

            var centerVertexIndex = 0;
            vertices[centerVertexIndex] = center;
            uv[centerVertexIndex] = new Vector2(0.5f, 0.5f);

            for (var i = 0; i < _markerSegmentsCount; ++i) {
                var currentVertexIndex = centerVertexIndex + i + 1;
                var firstTriangleIndex = i * 3;

                var angle = i * 2 * Mathf.PI / _markerSegmentsCount;
                vertices[centerVertexIndex + i + 1] = new Vector3(center.x + _markerRadius * Mathf.Cos(angle), _markerOffset, center.z + _markerRadius * Mathf.Sin(angle));
                uv[currentVertexIndex] = new Vector2(0.5f + 0.5f * Mathf.Cos(angle), 0.5f + 0.5f * Mathf.Sin(angle));

                triangles[firstTriangleIndex] = centerVertexIndex;
                triangles[firstTriangleIndex + 1] = i == _markerSegmentsCount - 1 ? centerVertexIndex + 1 : currentVertexIndex + 1;
                triangles[firstTriangleIndex + 2] = currentVertexIndex;
            }
        }

        private void GetBar(float barLength, float barWidth, out Vector3[] vertices, out Vector2[] uv, out int[] triangles) {
            vertices = new Vector3[4];
            uv = new Vector2[vertices.Length];
            triangles = new int[6];

            vertices[0] = new Vector3(-barLength / 2.0f, 0.0f, -_width / 2.0f);
            uv[0] = new Vector2(0.0f, 0.0f);

            vertices[1] = new Vector3(-barLength / 2.0f, 0.0f, _width / 2.0f);
            uv[1] = new Vector2(0.0f, 1.0f);

            vertices[2] = new Vector3(barLength / 2.0f, 0.0f, _width / 2.0f);
            uv[2] = new Vector2(1.0f, 1.0f);

            vertices[3] = new Vector3(barLength / 2.0f, 0.0f, -_width / 2.0f);
            uv[3] = new Vector2(1.0f, 0.0f);

            triangles[0] = 0;
            triangles[3] = triangles[2] = 3;
            triangles[4] = triangles[1] = 1;
            triangles[5] = 2;
        }
    }
}