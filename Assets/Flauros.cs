using UnityEngine;
using System.Collections;
using static UnityEditor.Searcher.SearcherWindow.Alignment;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class Flauros : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Create();
    }

    // Update is called once per frame
    void Create()
    {
        Vector3[] vertices = {
            new Vector3(0, 0, 1),   // 0
            new Vector3(1, 0, 0),   // 1
            new Vector3(0, 1, 0),   // 2
            new Vector3(-1, 0, 0),  // 3
            new Vector3(0, 0, -1),  // 4
            new Vector3(0, -1, 0),  // 5
            new Vector3(1, 0, 0),   //1 - 6
            new Vector3(1, 0, 0),   //1 - 7
            new Vector3(0, 1, 0),   //2 - 8
            new Vector3(-1, 0, 0)   //3 - 9
        };

        int[] triangles = {
            0, 1, 2,
            0, 2, 3,
            0, 3, 5,
            0, 5, 6,
            4, 6, 5,
            4, 8, 7,
            4, 9, 8,
            4, 5, 9
        };


        Vector2[] uvs = {
            new Vector2(0.8455f, 0.43f),  //0
            new Vector2(0.96f, 0.281f),   //1
            new Vector2(0.74f, 0.281f),   //2
            new Vector2(0.6f, 0.43f),     //3
            new Vector2(0.8455f, 0.775f), //4
            new Vector2(0.72f, 0.605f),   //5
            new Vector2(0.96f, 0.60f),    //1 - 6
            new Vector2(0.96f, 0.95f),    //1 - 7
            new Vector2(.725f, 0.95f),    //2 - 8
            new Vector2(.6f, 0.775f)      //3 - 9
        };

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals();
    }
}
