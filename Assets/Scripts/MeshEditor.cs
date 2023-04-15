using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class MeshEditor : MonoBehaviour
{
    public List<Transform> vertices = new List<Transform>();
    public Vector3[] v;
    void Start()
    {
        var mesh = GetComponent<MeshFilter>().sharedMesh;
        var newMesh = new Mesh();
        newMesh.Clear();
        newMesh.vertices = mesh.vertices;
        newMesh.triangles = mesh.triangles;
        newMesh.uv = mesh.uv;
        newMesh.name = "cloned_mesh";
        newMesh.RecalculateNormals();
        GetComponent<MeshFilter>().sharedMesh = newMesh;
    }
    private void Update()
    {
        var mesh = GetComponent<MeshFilter>().sharedMesh;
        if (vertices.Count != mesh.vertices.Length)
            InstantiateControllers(mesh);
        bool isDirty = false;
        for (int i = 0; i < v.Length; ++i)
        {
            if (v[i] != vertices[i].localPosition)
            {
                v[i] = vertices[i].localPosition;
                isDirty = true;
            }
        }
        if (isDirty)
        {
            mesh.vertices = v;
            var triangles = mesh.triangles;
            int triangleCount = triangles.Length / 3;
            Vector3[] normals = new Vector3[v.Length];
            int[] vis = new int[v.Length];
            for (int i = 0; i < triangleCount; ++i)
            {
                Vector3 a = v[triangles[i * 3]];
                Vector3 b = v[triangles[i * 3 + 1]];
                Vector3 c = v[triangles[i * 3 + 2]];
                var n = Vector3.Cross(b - a, c - a).normalized;
                normals[triangles[i * 3]] += n;
                normals[triangles[i * 3 + 1]] += n;
                normals[triangles[i * 3 + 2]] += n;
                ++vis[triangles[i * 3]];
                ++vis[triangles[i * 3 + 1]];
                ++vis[triangles[i * 3 + 2]];
            }
            for (int i = 0; i < v.Length; ++i)
                normals[i] /= vis[i];
            mesh.normals = normals;
        }
    }
    void InstantiateControllers(Mesh mesh)
    {
        foreach (var t in vertices)
            Destroy(t.gameObject);
        vertices.Clear();
        v = mesh.vertices;
        for (int i = 0; i < mesh.vertices.Length; ++i)
        {
            var o = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            o.name = "vert" + i;
            o.transform.parent = transform;
            o.transform.localEulerAngles = Vector3.zero;
            o.transform.localScale = Vector3.one * .05f;
            o.transform.localPosition = mesh.vertices[i];
            vertices.Add(o.transform);
        }
    }
}