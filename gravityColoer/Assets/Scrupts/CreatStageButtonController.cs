using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatStageButtonController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameData gameData;

    [SerializeField]
    private Dropdown dw;
    [SerializeField]
    private InputField stageScaleText;

    [Header("wall"), SerializeField]
    private GameObject upWallObj;
    [SerializeField]
    private GameObject downWallObj;
    [SerializeField]
    private GameObject rightWallObj;
    [SerializeField]
    private GameObject leftWallObj;
    [SerializeField]
    private float wallThickness;//壁の厚さ
    private bool isInstanceWall;//壁データが存在しているか


    private int cubeMatNum;

    private void Start()
    {
        isInstanceWall = false;
        stageScaleText.text = stageData.stageScale.ToString();
        if (stageScaleText.text != null) InstanceWall();
    }

    public void InstanceWall()
    {

        //場所と大きさの計算
        int stageScale = int.Parse(stageScaleText.text);
        float wallScale = wallThickness * 2 + stageScale;
        float wallPos = wallScale / 2 - wallThickness / 2;

        //それぞれの大きさ
        upWallObj.transform.localScale    = new Vector2(wallScale,wallThickness);
        downWallObj.transform.localScale  = new Vector2(wallScale,wallThickness);
        rightWallObj.transform.localScale = new Vector2(wallThickness, wallScale);
        leftWallObj.transform.localScale  = new Vector2(wallThickness, wallScale);

        //それぞれの位置
        upWallObj.transform.position    = new Vector2(0, wallPos);
        downWallObj.transform.position  = new Vector2(0, -wallPos);
        rightWallObj.transform.position = new Vector2(wallPos, 0);
        leftWallObj.transform.position  = new Vector2(-wallPos, 0);

        //保存
        stageData.stageScale = int.Parse(stageScaleText.text);
        stageData.wallData[0].wallObj = upWallObj;
        stageData.wallData[1].wallObj = downWallObj;
        stageData.wallData[2].wallObj = rightWallObj;
        stageData.wallData[3].wallObj = leftWallObj;
        for (int i = 0; i < stageData.wallData.Length; i++)
        {
            stageData.wallData[i].wallPos = stageData.wallData[i].wallObj.transform.position;
            stageData.wallData[i].wallScale = stageData.wallData[i].wallObj.transform.position;
        }

        //生成
        if (!isInstanceWall)
        {
            for(int i=0; i < stageData.wallData.Length; i++)
            {
                Instantiate(stageData.wallData[i].wallObj).name = stageData.wallData[i].wallObj.name;
            }
            isInstanceWall = true;
        }
        else
        {
            for (int i = 0; i < stageData.wallData.Length; i++)
            {
                GameObject.Find(stageData.wallData[i].wallObj.name).transform.position = stageData.wallData[i].wallObj.transform.position;
                GameObject.Find(stageData.wallData[i].wallObj.name).transform.localScale = stageData.wallData[i].wallObj.transform.localScale;
            }
        }


    }

    public void InstanceCube(GameObject cube)
    {
        Debug.Log(gameData.wallMat[cubeMatNum]);
        Instantiate(cube).GetComponent<MeshRenderer>().material = gameData.wallMat[cubeMatNum];
    }

    public void ChangeCubeMat()
    {
        cubeMatNum = dw.value;
    }
}
