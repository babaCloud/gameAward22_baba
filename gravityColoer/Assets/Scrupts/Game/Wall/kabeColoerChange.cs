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

        //�ǎ擾
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
    /// �N���b�N�����I�u�W�F�N�g�̎擾
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
    /// �N���b�N�����I�u�W�F�N�g�̃^�C�v��ς��A���̃f�[�^��ۑ�
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
    /// �}�b�v�̉�]
    /// </summary>
    void RotetionMap()
    {
        //��]�X�^�[�g
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isLeftRotation && !isRightRotation)
        {
            isLeftRotation = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isLeftRotation && !isRightRotation)
        {
            isRightRotation = true;
        }

        //��]
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

        //��]�X�g�b�v���덷����
        if (Mathf.Abs(angle) > 90.0f)
        {
            if (isLeftRotation) map.transform.localEulerAngles = new Vector3(0, 0, (float)Math.Round(map.transform.localEulerAngles.z, MidpointRounding.AwayFromZero));
            if (isRightRotation) map.transform.localEulerAngles = new Vector3(0, 0, (float)Math.Round(map.transform.localEulerAngles.z, MidpointRounding.AwayFromZero));

            isRightRotation = false;
            isLeftRotation = false;
            angle = 0.0f;

            //�ǂ̃f�[�^(�F�ƈʒu������)
            for (int i = 0; i < kabe.Length; i++)
            {
                mapData.wallData[i] = kabe[i].GetComponent<WallDirectionManager>().GetWallDirectionColor();
            }
        }

        mapData.mapAngleMoveAmount = angle;
    }
}
