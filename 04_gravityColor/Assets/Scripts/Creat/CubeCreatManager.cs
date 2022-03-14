using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CubeCreatManager : MonoBehaviour
{
       
    [SerializeField]
    private GameData gameData;
    public StageData stageData;

    [SerializeField]
    private Dropdown dw;

    private List<GameObject> cubeList = new List<GameObject>();
    private int cubeMatNum;
    private int cubeNum;
    private GameObject clickObj;

    public GameObject initObj;

    private void Start()
    {

        LoadCubeData();
    }

    private void Update()
    {
        MousePosition();
        DeleteCube(clickObj);
        MoveCube();
        FitToStageSize();
    }

    /// <summary>
    /// �N���b�N�����I�u�W�F�N�g���Q��
    /// </summary>
    void MousePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickObj = hit.collider.gameObject;
            }
            else
            {
                clickObj = null;
            }
        }

    }

    /// <summary>
    /// �}�E�X�ňړ�(�}�X�P��)
    /// </summary>
    void MoveCube()
    {       

        if (Input.GetMouseButton(0) && clickObj != null)
        {
            //���W�ϊ�
            Vector3 position = Input.mousePosition;
            position.z = 10;//ScreenToWorldPoint�ɕϊ�����Ƃ��Ƀo�O��̂�
            position = Camera.main.ScreenToWorldPoint(position);
            position = new Vector3((float)Math.Round(position.x, MidpointRounding.AwayFromZero),
                (float)Math.Round(position.y, MidpointRounding.AwayFromZero), 0);
            if (stageData.stageScale % 2 == 0)�@position += new Vector3(0.5f, 0.5f, 0);
            
            //�ړ�
            clickObj.transform.position = position;
        }

    }

    /// <summary>
    /// �X�e�[�W�̃}�X�ڂɍ��킹��
    /// </summary>
    void FitToStageSize()
    {
        //�����Ȃ�.5�ɂ���
        if (stageData.stageScale % 2 == 0)
        {
            for(int i = 0; i < cubeList.Count; i++)
            {
                if(cubeList[i].transform.position.x- (float)Math.Round(cubeList[i].transform.position.x, MidpointRounding.AwayFromZero) == 0)
                {
                    cubeList[i].transform.position += new Vector3(0.5f, 0.5f, 0);
                }
            }
        }
        else
        {
            for (int i = 0; i < cubeList.Count; i++)
            {
                if (cubeList[i].transform.position.x - (float)Math.Round(cubeList[i].transform.position.x, MidpointRounding.AwayFromZero) != 0)
                {
                    cubeList[i].transform.position -= new Vector3(0.5f, 0.5f, 0);
                }
            }
        }
    }

    /// <summary>
    /// �����CUBE�폜
    /// </summary>
    void DeleteCube(GameObject obj)
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            cubeList.Remove(obj);
            Destroy(obj);
        }
    }

    /// <summary>
    /// �{�^���������Ă̐���
    /// </summary>
    /// <param name="cube"></param>
    public void InstanceCube(GameObject cube)
    {
        cubeNum++;
        cube.GetComponent<MeshRenderer>().material = gameData.wallMat[cubeMatNum];
        GameObject obj = Instantiate(cube);
        string matName = obj.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "");
        obj.name = matName + " cube " + cubeNum;
        cubeList.Add(obj);
    }

    /// <summary>
    /// �F����
    /// </summary>
    public void ChangeCubeMat()
    {
        cubeMatNum = dw.value;
    }

    /// <summary>
    /// �f�[�^�̕ۑ�
    /// </summary>
    public void SaveCubeData()
    {
        Array.Resize<StageData.CubeData>( ref stageData.cubeData, cubeList.Count);

        for(int i = 0; i < cubeList.Count; i++)
        {
            //�ʒu
            stageData.cubeData[i].cubePos = cubeList[i].transform.position;

            //�F
            for(int j = 0; j < gameData.wallMat.Length; j++)
            {
                if(gameData.wallMat[j].name+ " (Instance)" == cubeList[i].GetComponent<MeshRenderer>().material.name)
                {
                    stageData.cubeData[i].cubeMat = gameData.wallMat[j];
                }
            }
            
        }
    }

    /// <summary>
    /// �f�[�^�̃��[�h
    /// </summary>
    void LoadCubeData()
    {
        for(int i = 0; i < stageData.cubeData.Length; i++)
        {
            var obj = Instantiate(initObj);
            obj.transform.position = stageData.cubeData[i].cubePos;
            obj.GetComponent<MeshRenderer>().material= stageData.cubeData[i].cubeMat;
            string matName = obj.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "");
            obj.name = matName + " cube " + cubeNum;
            cubeNum++;
            cubeList.Add(obj);
        }


    }
}
