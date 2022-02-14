using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class writeObj : MonoBehaviour
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
    private Rigidbody2D rig;

    private int vertexIndex;
    private Vector2[] edge;
    private Vector3 pos;

    void Start()
    {
        pos = playerObj.transform.position;
    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CreatPlayerObj();
            Position();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            playerObj.transform.position = pos;
            rig.bodyType = RigidbodyType2D.Static;
            transform.localRotation = new Quaternion(0, 0, 0, 0);
        }

        
    }

    /// <summary>
    /// オブジェクトの形成と当たり判定の追加
    /// </summary>
    void CreatPlayerObj()
    {
       
        vertexIndex = writeLine.positionCount;
        Array.Resize(ref edge, vertexIndex);
        playerLine.SetVertexCount(vertexIndex);

        for (int i = 0; i < vertexIndex; i++)
        {
            //線を描画
            playerLine.SetPosition(i,writeLine.GetPosition(i));

            //当たり判定
            edge[i] = writeLine.GetPosition(i);
            edgeCollider.points = edge;
        }

    }


    void Position()
    {
        rig.bodyType = RigidbodyType2D.Dynamic;
    }
}