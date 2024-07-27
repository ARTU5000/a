using UnityEngine;
using System.Collections;
using static UnityEditor.Searcher.SearcherWindow.Alignment;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class uvFlauros : MonoBehaviour
{
    public int type;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Create();
    }

    // Update is called once per frame
    void Create()
    {
        float height = Mathf.Sqrt(2f / 3f);
        Vector3[] vertices = {
            new Vector3(0, 0, 0),                   // 0
            new Vector3(1, 0, 0),                   // 1
            new Vector3(0.5f, 0, Mathf.Sqrt(0.75f)),  // 2 (Base)
            new Vector3(0.5f, height, 0.5f / Mathf.Sqrt(3f)),  // 3 (Punto superior)
            new Vector3(0.5f, height, 0.5f / Mathf.Sqrt(3f)),  // 4 (igual que 3)
            new Vector3(0.5f, height, 0.5f / Mathf.Sqrt(3f))   // 5 (igual que 3)
        };

        int[] triangles = {
            0, 1, 2,
            0, 2, 5,
            0, 4, 1,
            3, 2, 1,
        };

        Vector2[] uvs0 = {
            new Vector2(0.41f, 0.957f),    //0
            new Vector2(0.534f, 0.787f),   //1
            new Vector2(0.284f, 0.787f),   //2
            new Vector2(0.41f, 0.618f),    //3
            new Vector2(0.6615f, 0.9575f), //3 - 4
            new Vector2(0.1615f, 0.9575f), //3 - 5
        };

        Vector2[] uvs1 = {
            new Vector2(0.265f, 0.43f),    //0
            new Vector2(0.138f, 0.6f),     //1
            new Vector2(0.384f, 0.6f),     //2
            new Vector2(0.265f, 0.766f),   //3
            new Vector2(0.011f, 0.43f),    //3 - 4
            new Vector2(0.523f, 0.43f),    //3 - 5
        };

        Vector2[] uvs2 = {
            new Vector2(0.296f, 0.387f),   //0
            new Vector2(0.276f, 0.327f),   //1
            new Vector2(0.176f, 0.327f),   //2
            new Vector2(0.3f, 0.042f),     //3
            new Vector2(0.546f, 0.387f),   //3 - 4
            new Vector2(0.05f, 0.387f),    //3 - 5
        };

        Vector2[] uvs3 = {
            new Vector2(0.6f, 0.042f),     //0
            new Vector2(0.476f, 0.209f),   //1
            new Vector2(0.73f, 0.209f),    //2
            new Vector2(0.6f, 0.381f),     //3
            new Vector2(0.353f, 0.042f),   //3 - 4
            new Vector2(0.853f, 0.042f),   //3 - 5
        };

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        switch (type)
        {
            case 0:

                mesh.uv = uvs0;
                break;

            case 1:
                mesh.uv = uvs1;
                break;

            case 2:
                mesh.uv = uvs2;
                break;

            case 3:
                mesh.uv = uvs3;
                break;

            default:
                mesh.uv = uvs0;
                break;
        }
        mesh.Optimize();
        mesh.RecalculateNormals();
    }
}
