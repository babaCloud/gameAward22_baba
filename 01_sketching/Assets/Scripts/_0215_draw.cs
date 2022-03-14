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
    /// ���C��������
    /// </summary>
    void DrawLine()
    {
        //���_��ݒ�
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
        position.z = 10;//ScreenToWorldPoint�ɕϊ�����Ƃ��Ƀo�O��̂�
        vertex[vertexIndex - 1] = Camera.main.ScreenToWorldPoint(position);
        vertex[vertexIndex - 1].z = 0;


        //LineRender���g���ĕ`��
        lineRenderer.SetVertexCount(vertexIndex);
        lineRenderer.SetPositions(vertex);


    }
}
