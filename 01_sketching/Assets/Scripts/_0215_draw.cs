using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class _0215_draw : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;

    private int vertexIndex;
    private Vector3[] vertex;

    void Start()
    {

    }


    void Update()
    {
        DrawLine();
    }

    /// <summary>
    /// ラインを書く
    /// </summary>
    void DrawLine()
    {
        //頂点を設定
        if (Input.GetMouseButtonDown(0))
        {
            vertexIndex = 0;
            return;
        }
        else if (Input.GetMouseButton(0))
        {
            vertexIndex++;
        }
        else
        {
            return;
        }

        Array.Resize(ref vertex, vertexIndex);
        Vector3 position = Input.mousePosition;
        position.z = 10;//ScreenToWorldPointに変換するときにバグるので
        vertex[vertexIndex - 1] = Camera.main.ScreenToWorldPoint(position);
        vertex[vertexIndex - 1].z = 0;


        //LineRenderを使って描画
        lineRenderer.SetVertexCount(vertexIndex);
        lineRenderer.SetPositions(vertex);


    }
}
