using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private GameData gameData;
    [SerializeField]
    private GameObject cubeObj;

    [Header("�ǂ𐶐�����ꏊ"), SerializeField]
    private GameObject map;

    private void Awake()
    {
        SetGameData();
        InstanceWall();
        InstanceCube();
    }

    /// <summary>
    /// �Q�[�����Ɏg�p����f�[�^�̃Z�b�g
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
    /// �ǂ̐���
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
    /// �L���[�u�̐���
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
    /// �Q�[�����Ɏg�p����f�[�^���L
    /// </summary>
    /// <returns></returns>
    public GameData GetGameData()
    {
        return gameData;
    }
}
