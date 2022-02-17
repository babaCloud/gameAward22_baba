using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;
    [SerializeField]
    private TangentManager tangentObj;
    [SerializeField]
    private EdgeManager edgeObj;

    private bool isStart = false;//�N���b�N������X�^�[�g
    private Vector2 axis;//���˂���Ƃ��Ɏg����

    public float speed;//1�t���[�������艽��������
    public float gravity;//�d�͉����x
    private float g;//���ۂ̏d��

    private Vector2[] position;

    void Start()
    {
        position = new Vector2[2];
        gravity /= 1000;
    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isStart = true;
        }

        if (isStart)
        {
            PlayerMove();
        }
       
    }


    /// <summary>
    /// ball�̓���
    /// </summary>
    void PlayerMove()
    {
        position[0] = position[1];

        playerObj.transform.position += new Vector3(transform.right.x * speed, transform.right.y * (speed + g), 0);
        if (transform.right.y > 0) g -= gravity;//y�����Ȃ猸��
        else g += gravity;//���Ȃ����

        position[1] = new Vector2(transform.position.x,transform.position.y);
    }

    /// <summary>
    /// ball�̔���(�����ς��邾��)
    /// </summary>
    void PlayerReflection()
    {              
        transform.RotateAround(playerObj.transform.position, axis, 180.0f);//�ڐ������ɉ�]
        g = 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //��
        if (collision.gameObject.tag == "circle")
        {
            transform.right = collision.gameObject.transform.position - this.gameObject.transform.position;//���������I�u�W�F�N�g�̕�������
            axis = tangentObj.Line(playerObj.transform.position, collision.gameObject.gameObject.transform.position);//�ڐ��̐���
            PlayerReflection();
        }

        //��
        if(collision.gameObject.tag == "up")
        {
            transform.right = position[1] - position[0];
            axis = edgeObj.UpWorldPosition(collision.transform.parent.gameObject);
            PlayerReflection();
        }
        if (collision.gameObject.tag == "down")
        {
            transform.right = position[1] - position[0];
            axis = edgeObj.DownWorldPosition(collision.transform.parent.gameObject);
            PlayerReflection();
        }
        if (collision.gameObject.tag == "left")
        {
            transform.right = position[1] - position[0];
            axis = edgeObj.LeftWorldPosition(collision.transform.parent.gameObject);
            PlayerReflection();
        }
        if (collision.gameObject.tag == "right")
        {
            transform.right = position[1] - position[0];
            axis = edgeObj.RightWorldPosition(collision.transform.parent.gameObject);
            PlayerReflection();
        }

    }
  

}
