using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Chunk : MonoBehaviour
{
  MeshRenderer meshRenderer;
  MeshFilter meshFilter;
  GameObject chunkGO;
  Material material;
  public Material testMaterial;
  Texture2D texture;

  List<Vector3> vertices = new List<Vector3>();
  List<int> triangles = new List<int>();
  List<Vector2> uvs = new List<Vector2>();

  int vertexIndex = 0;

  // bool[,,] voxelMap = new bool[VoxelData.ChunkWidth, VoxelData.ChunkHeight, VoxelData.ChunkWidth];
  bool[,,] voxelMap = new bool[VoxelData.ChunkWidth, VoxelData.ChunkHeight, VoxelData.ChunkWidth];



  // Start is called before the first frame update
  void Awake()
  {
    chunkGO = new GameObject("chunk");
    meshRenderer = chunkGO.AddComponent<MeshRenderer>();
    meshFilter = chunkGO.AddComponent<MeshFilter>();
    chunkGO.transform.parent = gameObject.transform;

    material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    texture = Resources.Load<Texture2D>("Grasstile1");

  }

  void Start()
  {

    PopulateVoxelMap();



    CreateMeshData();


    CreateMesh();

  }

  void AddVoxelDataToChunk(Vector3 pos)
  {
    for (int y = 0; y < 6; y++)
    {
      if (CheckVoxel(pos + VoxelData.faceChecks[y]) == false)
      {
        Vector3 vert1 = pos + VoxelData.voxelVerts[VoxelData.voxelTris[y, 0]];
        Vector3 vert2 = pos + VoxelData.voxelVerts[VoxelData.voxelTris[y, 1]];
        Vector3 vert3 = pos + VoxelData.voxelVerts[VoxelData.voxelTris[y, 2]];
        Vector3 vert4 = pos + VoxelData.voxelVerts[VoxelData.voxelTris[y, 3]];

        vertices.Add(vert1);
        vertices.Add(vert2);
        vertices.Add(vert3);
        vertices.Add(vert4);

        uvs.Add(VoxelData.voxelUvs[0]);
        uvs.Add(VoxelData.voxelUvs[1]);
        uvs.Add(VoxelData.voxelUvs[2]);
        uvs.Add(VoxelData.voxelUvs[3]);

        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);
        triangles.Add(vertexIndex + 2);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 3);

        vertexIndex += 4;
      }
    }



  }

  void PopulateVoxelMap()
  {
    for (int y = 0; y < VoxelData.ChunkHeight; y++)
    {
      for (int x = 0; x < VoxelData.ChunkWidth; x++)
      {
        for (int z = 0; z < VoxelData.ChunkWidth; z++)
        {
          voxelMap[x, y, z] = true;
        }
      }
    }
  }

  void CreateMeshData()
  {
    for (int x = 0; x < VoxelData.ChunkWidth; x++)
    {
      for (int y = 0; y < VoxelData.ChunkHeight; y++)
      {
        for (int z = 0; z < VoxelData.ChunkWidth; z++)
        {
          AddVoxelDataToChunk(new Vector3(x, y, z));
        }
      }
    }
  }

  bool CheckVoxel(Vector3 pos)
  {
    int x = Mathf.FloorToInt(pos.x);
    int y = Mathf.FloorToInt(pos.y);
    int z = Mathf.FloorToInt(pos.z);

    if (x < 0 || x > VoxelData.ChunkWidth - 1)
    {
      return false;
    }
    if (y < 0 || y > VoxelData.ChunkHeight - 1)
    {
      return false;
    }

    if (z < 0 || z > VoxelData.ChunkWidth - 1)
    {
      return false;
    }


    return voxelMap[x, y, z];
  }

  void CreateMesh()
  {

    Mesh mesh = new Mesh();
    mesh.vertices = vertices.ToArray();
    mesh.triangles = triangles.ToArray();
    // mesh.uv = uvs.ToArray();
    mesh.SetUVs(0, uvs);

    mesh.RecalculateNormals();

    meshFilter.mesh = mesh;

    material.SetTexture("_BaseMap", texture);

    meshRenderer.material = material;
  }
}
