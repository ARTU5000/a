using UnityEngine;
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
            new Vector3(0, 0, 0),         //0
            new Vector3(.8f, 0, 0),       //1
            new Vector3(.4f, 0, .7f),  //2
            new Vector3( 0, .8f, .4f),    //3
            new Vector3(.8f, .8f, .4f),   //4
            new Vector3(.4f, .8f, -.3f)  //5
        };

        int[] triangles = {
            0, 1, 2,
            0, 2, 3,
            0, 3, 5,
            0, 5, 1,
            4, 1, 5,
            4, 2, 1,
            4, 3, 2,
            4, 5, 3
        };


        Mesh mesh = new Mesh();
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
