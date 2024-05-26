using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    // define world size
    public int worldX;
    public int worldZ;

    // create a mesh to be our new mesh
    private Mesh mesh;

    // define arrayes needed for the mesh
    private int[] triangles;
    private Vector3[] verticies;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        GenerateMesh();
        UpdateMesh();
    }

    void GenerateMesh()
    {
        triangles = new int[worldX * worldZ *6 ];
        verticies = new Vector3[(worldX + 1) * (worldZ + 1)];

        for(int i = 0, z = 0; z <= worldZ; z++)
        {
            for(int x = 0; x <= worldX; x++)
            {
                verticies[i] = new Vector3(x,0,z);
                i++;
            }
        }

        int tris = 0;
        int verts = 0;

        for (int z = 0; z < worldZ; z++)
        {
            for (int x = 0; x < worldX; x++)
            {
                triangles[tris + 0] = verts + 0;
                triangles[tris + 1] = verts + worldZ + 1;
                triangles[tris + 2] = verts + 1;

                triangles[tris + 3] = verts + 1;
                triangles[tris + 4] = verts + worldZ + 1;
                triangles[tris + 5] = verts + worldZ + 2;

                verts++;
                tris += 6;
            }
        verts++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = verticies;
        mesh.triangles = triangles;
        

        mesh.RecalculateNormals();
    }
}
