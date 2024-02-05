using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class WaterDisplayManager : MonoBehaviour
{
    private MeshFilter surfaceMeshFilter;
    void Awake()
    {
        surfaceMeshFilter = GetComponent<MeshFilter>();
    }
    
    void Update()
    {
        Vector3[] meshVertices = surfaceMeshFilter.mesh.vertices;

        for (int i = 0; i < meshVertices.Length; i++)
        {
            meshVertices[i].y = WaveManager.instance.GetWaveHeight(transform.position.x + meshVertices[i].x, transform.position.z + meshVertices[i].z);
        }

        surfaceMeshFilter.mesh.vertices = meshVertices;
        surfaceMeshFilter.mesh.RecalculateNormals();
    }
}
