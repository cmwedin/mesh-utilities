using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SadSapphicGames.MeshUtilities {
    public class MeshUtilityWrapper {
        private Mesh _mesh;
        MeshCollider meshCollider;
        static List<Vector3> newVertices = new List<Vector3>();
        static List<int> triangles = new List<int>();
        static List<Vector2> newUV = new List<Vector2>();

        // * Constructor
        public MeshUtilityWrapper(Mesh mesh) {
            this._mesh = mesh;
        }

        public void UpdateMesh() {
            _mesh.Clear();
            _mesh.vertices = newVertices.ToArray();
            _mesh.triangles = triangles.ToArray();
            _mesh.uv = newUV.ToArray();
        }
        public void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            int vertIndex = newVertices.Count;

            newVertices.Add(v1);
            newVertices.Add(v2);
            newVertices.Add(v3);

            triangles.Add(vertIndex);
            triangles.Add(vertIndex + 1);
            triangles.Add(vertIndex + 2);
        }
        public void AddTriangleUVs(Vector2 v1, Vector2 v2, Vector2 v3) {
            newUV.Add(v1);
            newUV.Add(v2);
            newUV.Add(v3);

        }
        public void AddQuad(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4)
        {
            int vertIndex = newVertices.Count;

            newVertices.Add(v1);
            newVertices.Add(v2);
            newVertices.Add(v3);
            newVertices.Add(v4);

            triangles.Add(vertIndex);
            triangles.Add(vertIndex + 2);
            triangles.Add(vertIndex + 1);

            triangles.Add(vertIndex + 1);
            triangles.Add(vertIndex + 2);
            triangles.Add(vertIndex + 3);
        }
        public void AddLineSegment(Vector3 v1, Vector3 v2, Vector3 brush) { //? QOL function, this could easily be made as a quad
            AddQuad(v1 - brush, v1 + brush, v2 + brush, v2 - brush);
        }
    }
}