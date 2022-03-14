using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class _0215_player : MonoBehaviour
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

    private bool isStart = false;
    private Vector3 pos;

    void Start()
    {
        rig.bodyType = RigidbodyType2D.Kinematic;
        pos = this.gameObject.transform.position;
    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CreatPlayerObj();
            Time.timeScale = 1.0f;
        }
        if (Input.GetMouseButtonDown(0))
        {
            isStart = true;
            Time.timeScale = 0.2f;
        }
        if (Input.GetMouseButton(0))
        {

        }

        if (isStart)
        {
            rig.bodyType = RigidbodyType2D.Dynamic;
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

}
