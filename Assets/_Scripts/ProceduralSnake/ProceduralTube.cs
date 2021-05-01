using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralTube : MonoBehaviour
{

    public float radius = 0.5f;
    public float segmentHeight = 1.0f;
    
    public int pointsPerSegment = 8;
    public int numOfSegments = 2;

    public int subSegments = 5;

    public Material material;

    public Color color;
    private List<Vector4> positions;

    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    
    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        
    }

    
    void Start()
    {
        GetComponent<MeshRenderer>().material = material;
        material.SetColor("_Color", color);

        positions = new List<Vector4>();
        for(int i = 0; i < 128; i++) //Initialize 128 positions for array (max-capability for fixed-size array in shader;
            positions.Add(new Vector4());

        Test();

        MakeProceduralTube();
        UpdateMesh();
        
    }

    /// <summary>
    /// Set a new position to the snake 
    /// </summary>
    /// <param name="newPos">List of new positions</param>
    /// <param name="headRotation">Rotation of the head</param>
    void SetSnakePositions(List<Vector2> newPos, float headRotation )
    {
        positions[0] = new Vector4(newPos[0].x, newPos[0].y, headRotation, 0);
        for(int i = 1; i<newPos.Count; i++)
        {

            float rotation = positions[i - 1].z + positions[i - 1].w;

            float curve = 0;
            Vector2 vectorA = new Vector2(
                newPos[i].x - newPos[i - 1].x,
                newPos[i].y - newPos[i - 1].y
            );
            if(i != newPos.Count - 1) { 
                Vector2 vectorB = new Vector2(
                    newPos[i + 1].x - newPos[i].x,
                    newPos[i + 1].y - newPos[i].y
                );

                float ang = Vector2.SignedAngle(vectorA, vectorB);
                if (ang == 0)
                    curve = 0;
                else if (ang > 0)
                    curve = 0.25f;
                else
                    curve = -0.25f;
            }

            //float curve; 
            positions[i] = new Vector4(
                newPos[i].x, 
                newPos[i].y, 
                rotation, 
                curve
            );
        }

        positions[newPos.Count] = new Vector4(positions[newPos.Count - 1].x, 
                                              positions[newPos.Count - 1].y, 
                                              positions[newPos.Count - 1].z, 
                                              0);
    }


    [ContextMenu("Debug/TestNewPositions")]
    void Test()
    {
        
        SetSnakePositions(new List<Vector2> {
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(2,1),
            new Vector2(2,2),
            new Vector2(2,3),
            new Vector2(3,3) }, 0);
    }


    [ContextMenu("MakeProcedural")]
    void MakeProceduralTube()
    {
        // Set array sizes
        int numOfVertices = pointsPerSegment * (numOfSegments * subSegments + 1);

        vertices = new Vector3[numOfVertices];
        triangles = new int[pointsPerSegment * 6 * numOfSegments * subSegments];
        
        // Set vertex offset? 


        // Populate the vertices and triangles arrays
        for(int i = 0; i < numOfVertices; i++)
        {
            vertices[i] = new Vector3(
                Mathf.Cos( Mathf.PI * 2 * ( (float) i) / pointsPerSegment ) * radius  , 
                i / pointsPerSegment * segmentHeight / subSegments * 0.0f, 
                Mathf.Sin((Mathf.PI * 2 * (float) i) / pointsPerSegment) * radius 
                ) ;
            // print(vertices[i]);
            Debug.Log(vertices[i].ToString());
        }

        for(int i = 0; i < pointsPerSegment * (numOfSegments * subSegments) ; i++)
        {
            if(i % (pointsPerSegment) == pointsPerSegment - 1)
            {
                triangles[i * 6 + 0] = 0 + i;
                triangles[i * 6 + 1] = pointsPerSegment + i;
                triangles[i * 6 + 2] = 1 + i - pointsPerSegment;
                triangles[i * 6 + 3] = pointsPerSegment + i;
                triangles[i * 6 + 4] = pointsPerSegment + 1 + i - pointsPerSegment;
                triangles[i * 6 + 5] = 1 + i - pointsPerSegment;
                
            }
            else
            {
                triangles[i * 6 + 0] = 0 + i;
                triangles[i * 6 + 1] = pointsPerSegment + i;
                triangles[i * 6 + 2] = 1 + i;
                triangles[i * 6 + 3] = pointsPerSegment + i;
                triangles[i * 6 + 4] = pointsPerSegment + 1 + i;
                triangles[i * 6 + 5] = 1 + i;
            }
            
        }
        material.SetInt("_NumOfVertices", numOfVertices);

        material.SetInt("_SubSegments", subSegments);
        material.SetInt("_PointsPerSegment", pointsPerSegment);
         // _SubSegments;
        // _PointsPerSegment
    }

    [ContextMenu("UpdateMesh")]
    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        //mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        //material.SetInt("_Positions_Length", positions.Count);
        material.SetInt("_NumOfSegments", numOfSegments);
        for(int i = 0; i < positions.Count; i++)
        {  
            material.SetVectorArray("_Positions", positions);
        }
    }
}
