using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeController : MonoBehaviour
{
    [SerializeField]
    private MapData mapData;

    private int myMatNum;
    private Vector3 dirction = Vector2.zero;
    public float moveSpeed;
    private float angle;
    private float hoge = 0.1f;
    
    void Start()
    {
     
        for(int i=0; i < mapData.wallMat.Length; i++)
        {
            if(mapData.wallMat[i].name + (" (Instance)") == this.gameObject.GetComponent<MeshRenderer>().material.name)
            {
                myMatNum = i;
            }
           
        }
    }

    
    void Update()
    {
        DecideDirection();
        MoveCube();
    }

    /// <summary>
    /// 向きを決める
    /// </summary>
    void DecideDirection()
    {
        for(int i = 0; i < mapData.wallData.Length; i++)
        {
            if(myMatNum == mapData.wallData[i].colorNum)
            {
                dirction = mapData.wallData[i].pos;
                
                break;
            }
            else if(myMatNum != mapData.wallData[mapData.wallData.Length - 1].colorNum)
            {
                dirction = Vector2.down;
            }

        }
    }

    /// <summary>
    /// Cubeの動き
    /// </summary>
    void MoveCube()
    {
        

        //マップの回転と一緒に移動
        if (kabeColoerChange.isLeftRotation || kabeColoerChange.isRightRotation)
        {
            float centerToDiatanse = Mathf.Sqrt(Mathf.Pow(this.gameObject.transform.position.x, 2) + Mathf.Pow(this.gameObject.transform.position.y, 2));
            this.gameObject.transform.localEulerAngles = new Vector3(0, 0, mapData.mapAngleMoveAmount);
            this.gameObject.transform.position = new Vector2(centerToDiatanse * Mathf.Cos((angle + mapData.mapAngleMoveAmount) / 180.0f * Mathf.PI),
                                                            centerToDiatanse * Mathf.Sin((angle + mapData.mapAngleMoveAmount) / 180.0f * Mathf.PI));
        }
        else
        {
            //どの角度にいるか
            var diff = transform.position;
            var axis = Vector3.Cross(Vector2.right, diff);
            angle = Vector3.Angle(Vector2.right, diff);
            if (axis.z < 0) angle = 360.0f-angle;
            if (angle > 360.0f) angle -= 360.0f;


            //何かに当たるまで移動
            RaycastHit hit;
            if (!Physics.Raycast(gameObject.transform.position, dirction, out hit, 0.5f))
            {
                gameObject.transform.position += dirction * moveSpeed;
            }
        }

    }
}
