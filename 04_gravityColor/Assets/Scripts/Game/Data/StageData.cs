using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StageData")]
public class StageData : ScriptableObject
{
    public string stageName;
    public int stageScale;

    [System.Serializable]
    public struct WallData
    {
        public GameObject wallObj;

        public WallData(GameObject wallObj)
        {
            this.wallObj = wallObj;
        }
    }
    public WallData[] wallData = new WallData[4];

    [System.Serializable]
    public struct CubeData
    {
        public Vector2 cubePos;
        public Material cubeMat;

        public CubeData(Vector2 cubePos,Material cubeMat)
        {
            this.cubePos = cubePos;
            this.cubeMat = cubeMat;
        }
    }
    public CubeData[] cubeData = new CubeData[10];

   
}
