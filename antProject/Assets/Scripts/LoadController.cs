using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadController : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;

    private int vertexIndex;
    private Vector3[] vertex;

    void Start()
    {

    }


    void FixedUpdate()
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
            //vertexIndex++;
        }
        else
        {
            return;
        }


        Vector3 position = Input.mousePosition;
        position.z = 10;//ScreenToWorldPoint�ɕϊ�����Ƃ��Ƀo�O��̂�
        Vector3 pos= Camera.main.ScreenToWorldPoint(position);

        if (vertexIndex == 0)
        {
            vertexIndex++;
            Array.Resize(ref vertex, vertexIndex);
            vertex[vertexIndex-1] = pos;
            vertex[vertexIndex-1].z = 0;

        }
        if(pos != vertex[vertexIndex - 1])
        {
            vertexIndex++;
            Array.Resize(ref vertex, vertexIndex);
            vertex[vertexIndex-1] = pos;
            vertex[vertexIndex-1].z = 0;
        }

        //LineRender���g���ĕ`��
        lineRenderer.SetVertexCount(vertexIndex);
        lineRenderer.SetPositions(vertex);
    }
}
