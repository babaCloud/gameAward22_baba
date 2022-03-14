using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private GameData gameData;
    [SerializeField]
    private GameObject cubeObj;

    [Header("壁を生成する場所"), SerializeField]
    private GameObject map;

    private void Awake()
    {
        SetGameData();
        InstanceWall();
        InstanceCube();
    }

    /// <summary>
    /// ゲーム中に使用するデータのセット
    /// </summary>
    void SetGameData()
    {
        for(int i = 0; i < gameData.stageData.wallData.Length; i++)
        {
            gameData.wallData[i].pos = gameData.stageData.wallData[i].wallObj.transform.position;
            gameData.wallData[i].colorNum = 0;
            
        }
        
    }

    /// <summary>
    /// 壁の生成
    /// </summary>
    void InstanceWall()
    {
        for(int i = 0; i < gameData.stageData.wallData.Length; i++)
        {
            var wall= Instantiate(gameData.stageData.wallData[i].wallObj);
            wall.transform.parent = map.transform;
            wall.AddComponent<WallDirectionManager>();
            wall.name = gameData.stageData.wallData[i].wallObj.name;
        }
    }

    /// <summary>
    /// キューブの生成
    /// </summary>
    void InstanceCube()
    {
        int num = 0;

        for (int i = 0; i < gameData.stageData.cubeData.Length; i++)
        {
            var cube = Instantiate(cubeObj);
            cube.transform.position = gameData.stageData.cubeData[i].cubePos;
            cube.GetComponent<MeshRenderer>().material = gameData.stageData.cubeData[i].cubeMat;
            string matName = cube.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "");
            cube.name = matName + " cube " + num;
            num++;
        }
    }

    /// <summary>
    /// ゲーム中に使用するデータ共有
    /// </summary>
    /// <returns></returns>
    public GameData GetGameData()
    {
        return gameData;
    }
}
