using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class kabeColoerChange : MonoBehaviour
{
    [SerializeField]
    private GameObject map;

    private GameObject[] kabe = new GameObject[4];
    private GameObject clickObj;

    public static bool isLeftRotation = false;
    public static bool isRightRotation = false;
    public float rotationSpeed;
    private float angle;

    [SerializeField]
    private StageManager stageManager;
    private GameData mapData;
    private StageData stageData;

    void Start()
    {
        stageData = stageManager.GetStageData();
        mapData = stageManager.GetGameData();

        //壁取得
        for(int i = 0; i < stageData.wallData.Length; i++)
        {
            if (GameObject.Find(stageData.wallData[i].wallObj.name))
            {
                kabe[i] = GameObject.Find(stageData.wallData[i].wallObj.name);
            }
        }
        
    }


    void FixedUpdate()
    {
        GetClickObj();
        RotetionMap();
    }

    /// <summary>
    /// クリックしたオブジェクトの取得
    /// </summary>
    /// <returns></returns>
    void GetClickObj()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickObj = hit.collider.gameObject;
            }

            ClickToChange();
        }

    }

    /// <summary>
    /// クリックしたオブジェクトのタイプを変え、そのデータを保存
    /// </summary>
    void ClickToChange()
    {
        for(int i = 0; i < kabe.Length; i++)
        {
            if (clickObj == kabe[i])
            {
                Material nowMat = kabe[i].GetComponent<MeshRenderer>().material;

                for (int j = 0; j < mapData.wallMat.Length; j++)
                {
                    if(nowMat.name == mapData.wallMat[mapData.wallMat.Length-1].name + " (Instance)")
                    {
                        kabe[i].GetComponent<MeshRenderer>().material = mapData.wallMat[0];
                        kabe[i].GetComponent<WallDirectionManager>().SetColorNum(0);
                        break;
                    }
                    else if (nowMat.name == mapData.wallMat[j].name+ " (Instance)")
                    {
                        kabe[i].GetComponent<MeshRenderer>().material = mapData.wallMat[j+1];
                        kabe[i].GetComponent<WallDirectionManager>().SetColorNum(j+1);
                        break;
                    }                   
                }

                mapData.wallData[i] = kabe[i].GetComponent<WallDirectionManager>().GetWallDirectionColor();
            }
        }
    }


    /// <summary>
    /// マップの回転
    /// </summary>
    void RotetionMap()
    {
        //回転スタート
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isLeftRotation && !isRightRotation)
        {
            isLeftRotation = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isLeftRotation && !isRightRotation)
        {
            isRightRotation = true;
        }

        //回転
        if (isLeftRotation)
        {
            map.transform.localEulerAngles += new Vector3(0, 0, rotationSpeed);
            angle += rotationSpeed;
        }
        if (isRightRotation)
        {
            map.transform.localEulerAngles -= new Vector3(0, 0, rotationSpeed);
            angle -= rotationSpeed;
        }

        //回転ストップ＆誤差直し
        if (Mathf.Abs(angle) > 90.0f)
        {
            if (isLeftRotation) map.transform.localEulerAngles = new Vector3(0, 0, (float)Math.Round(map.transform.localEulerAngles.z, MidpointRounding.AwayFromZero));
            if (isRightRotation) map.transform.localEulerAngles = new Vector3(0, 0, (float)Math.Round(map.transform.localEulerAngles.z, MidpointRounding.AwayFromZero));

            isRightRotation = false;
            isLeftRotation = false;
            angle = 0.0f;

            //壁のデータ(色と位置を入れる)
            for (int i = 0; i < kabe.Length; i++)
            {
                mapData.wallData[i] = kabe[i].GetComponent<WallDirectionManager>().GetWallDirectionColor();
            }
        }

        mapData.mapAngleMoveAmount = angle;
    }
}
