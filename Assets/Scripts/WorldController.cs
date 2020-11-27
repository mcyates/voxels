using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WorldController : MonoBehaviour
{
  string assetsFilePath = Application.streamingAssetsPath;
  DirectoryInfo directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);

  Material material;
  public BlockType[] blockTypes;

  void Start()
  {
    string testJSON = System.IO.File.ReadAllText($"{assetsFilePath}/test.json");
    print(testJSON);
  }

  void LoadAssets()
  {

  }
}

[System.Serializable]
public class BlockType
{
  public string blockName;
  public bool IsSolid;
}
