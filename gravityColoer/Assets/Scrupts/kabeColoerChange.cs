using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class kabeColoerChange : MonoBehaviour
{
    [SerializeField]
    private GameObject map;

    [SerializeField]
    private GameObject[] kabe;

    [SerializeField]
    private Material[] mat;

    private GameObject clickObj;

    private bool isLeftRotation = false;
    private bool isRightRotation = false;
    public float rotationSpeed;
    private float angle;

    private WallDirectionManager.Wall[] wallData=new WallDirectionManager.Wall[4];

    void Start()
    {      
        for(int i = 0; i < kabe.Length; i++)
        {
            wallData[i] = kabe[i].GetComponent<WallDirectionManager>().GetWallDirectionColor();
            Debug.Log(kabe[i].name + wallData[i].colorNum);
        }
    }


    void Update()
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
    /// �N���b�N�����I�u�W�F�N�g�̃^�C�v��ς���
    /// </summary>
    void ClickToChange()
    {
        for(int i = 0; i < kabe.Length; i++)
        {
            if (clickObj == kabe[i])
            {
                Material nowMat = kabe[i].GetComponent<MeshRenderer>().material;
                WallDirectionManager wallColor = new WallDirectionManager();

                for (int j = 0; j < mat.Length; j++)
                {
                    if(nowMat.name == mat[mat.Length-1].name + " (Instance)")
                    {
                        kabe[i].GetComponent<MeshRenderer>().material = mat[0];
                        wallColor=kabe[i].GetComponent<WallDirectionManager>();
                        wallColor.SetColorNum(0);
                        break;
                    }
                    else if (nowMat.name == mat[j].name+ " (Instance)")
                    {
                        kabe[i].GetComponent<MeshRenderer>().material = mat[j+1];
                        wallColor = kabe[i].GetComponent<WallDirectionManager>();
                        wallColor.SetColorNum(j+1);
                        break;
                    }                   
                }
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
            angle += rotationSpeed;
        }

        //��]�X�g�b�v���덷����
        if (angle > 90.0f)
        {
            if (isLeftRotation) map.transform.localEulerAngles = new Vector3(0, 0, (float)Math.Round(map.transform.localEulerAngles.z, MidpointRounding.AwayFromZero));
            if (isRightRotation) map.transform.localEulerAngles = new Vector3(0, 0, (float)Math.Round(map.transform.localEulerAngles.z, MidpointRounding.AwayFromZero));

            isRightRotation = false;
            isLeftRotation = false;
            angle = 0.0f;

            for (int i = 0; i < kabe.Length; i++)
            {
                wallData[i] = kabe[i].GetComponent<WallDirectionManager>().GetWallDirectionColor();

            }
        }
    }
}
