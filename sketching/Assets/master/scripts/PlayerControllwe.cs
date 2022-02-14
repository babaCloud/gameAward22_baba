using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControllwe : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;
    [SerializeField]
    private LineRenderer writeLine;
    [SerializeField]
    private LineRenderer playerLine;
    [SerializeField]
    private EdgeCollider2D edgeCollider;
    [SerializeField]
    private GameObject tangentObj;


    private int vertexIndex;
    private Vector2[] edge;
    private Vector3 pos;
    private bool isStart = false;
    private Vector2 axis;

    public float speed;
    private TangentContolloer tan;

    void Start()
    {
        pos = playerObj.transform.position;
        tan = tangentObj.GetComponent<TangentContolloer>();
    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CreatPlayerObj();
            isStart = true;
        }

        if (isStart)
        {
            PlayerMove();
        }

    }

    /// <summary>
    /// オブジェクトの形成
    /// </summary>
    void CreatPlayerObj()
    {

        vertexIndex = writeLine.positionCount;
        Array.Resize(ref edge, vertexIndex);
        playerLine.SetVertexCount(vertexIndex);

        for (int i = 0; i < vertexIndex; i++)
        {
            //線を描画
            playerLine.SetPosition(i, writeLine.GetPosition(i));

            //当たり判定
            edge[i] = writeLine.GetPosition(i);
            edgeCollider.points = edge;
        }

    }

    void PlayerMove()
    {
        //playerObj.transform.position += new v
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "circle")
        {
            axis=tan.Line(playerObj.transform.position,collision.gameObject);
            transform.RotateAround(playerObj.transform.position, axis, 180.0f);
           
        }
    }

}
