using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VoxelData
{
  public static readonly float size = 2f;

  public static readonly int ChunkWidth = 12;
  public static readonly int ChunkHeight = 4;

  // Start is called before the first frame update
  public static readonly Vector3[] voxelVerts = new Vector3[] {
    // o,0,0 is on the bottom SW 1,1,1 is on the top NE
    // replace size with 1f if it stops working

      new Vector3(0.0f,0.0f,0.0f),
      new Vector3(size,0.0f,0.0f),
      new Vector3(size,size,0.0f),
      new Vector3(0.0f,size,0.0f),

      new Vector3(0.0f,0.0f,size),
      new Vector3(size,0.0f,size),
      new Vector3(size,size,size),
      new Vector3(0.0f,size,size),
  };

  public static readonly Vector3[] faceChecks = new Vector3[] {

      new Vector3(0.0f,0.0f,-1.0f), // back face
      new Vector3(0.0f,0.0f,1.0f), // front face
      new Vector3(0.0f,1.0f,0.0f), // Top Face
      new Vector3(0.0f,-1.0f,0.0f), // Bottom Face
      new Vector3(-1.0f,0.0f,0.0f), // left face
      new Vector3(1.0f,0.0f,0.0f), // right face
       
      // new Vector3(0.0f,0.0f,-size), // back face
      // new Vector3(0.0f,0.0f,size), // front face
      // new Vector3(0.0f,size,0.0f), // Top Face
      // new Vector3(0.0f,-size,0.0f), // Bottom Face
      // new Vector3(-size,0.0f,0.0f), // left face
      // new Vector3(size,0.0f,0.0f), // right face
  };

  public static readonly int[,] voxelTris = new int[6, 4] {

      {0,3,1,2}, // Back Face
      {5,6,4,7}, // Front Face
      {3,7,2,6},// Top Face
      {1,5,0,4}, // Bottom Face
      {4,7,0,3}, // Left Face
      {1,2,5,6}, // Right Face
      

  };

  public static readonly Vector2[] voxelUvs = new Vector2[] {
    new Vector2(0f,0f),
    new Vector2(0f,1f),
    new Vector2(1f,0f),
    new Vector2(1f,1f),
  };


}
