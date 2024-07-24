using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Decaedro : MonoBehaviour
{
    void Start()
    {
        CreateDecaedro();
    }

    private void CreateDecaedro()
    {
        Vector3[] vertices = {
            new Vector3(0, 1, 0),         //0
            new Vector3(1, .1f, 0),       //1
            new Vector3(.8f, -.1f, .6f),  //2
            new Vector3(.3f, .1f, 1),     //3
            new Vector3(-.3f, -.1f, 1),   //4
            new Vector3(-.8f, .1f, .6f),  //5
            new Vector3(-1f, -.1f, 0),    //6
            new Vector3(-.8f, .1f, -.6f), //7
            new Vector3(-.3f, -.1f, -1),  //8
            new Vector3(.3f, .1f, -1),    //9
            new Vector3(.8f, -.1f, -.6f), //10
            new Vector3(0, -1, 0)         //11
        };

        int[] triangles = {
            0, 2, 1, 
            0, 3, 2, 
            0, 4, 3, 
            0, 5, 4, 
            0, 6, 5,
            0, 7, 6,
            0, 8, 7,
            0, 9, 8,
            0, 10, 9,
            0, 1, 10,
            11, 1, 2,
            11, 2, 3,
            11, 3, 4,
            11, 4, 5,
            11, 5, 6,
            11, 6, 7,
            11, 7, 8,
            11, 8, 9,
            11, 9, 10,
            11, 10, 1,
        };

        Mesh mesh = new Mesh();
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
