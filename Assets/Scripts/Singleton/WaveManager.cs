using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    
    [SerializeField] Material waterMat;
    [SerializeField] MeshFilter waterSurface;
    public float amplitude = 1f;
    [SerializeField] public float length = 2f;
    [SerializeField] public float speed = 1f;
    [SerializeField] public float offset = 0f;

    private Vector3[] currentVertices;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("An instance of WaveManager already exists. Destroying additional WaveManager object");
            Destroy(this);
        }
    }
    
    void Update()
    {
        
        offset += Time.deltaTime * speed;
    }

    public float GetWaveHeight(float currentX, float currentZ)
    {
        currentVertices = waterSurface.mesh.vertices;
        for (int i = 0; i < currentVertices.Length; i++)
        {
            if (Mathf.Abs(currentVertices[i].x - currentX) <= 0.7 && Mathf.Abs(currentVertices[i].z - currentZ) <= 0.7)
            {
                return currentVertices[i].y;
            }
        }

        return waterSurface.transform.position.y;
    }
}
