using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;
    [SerializeField]
    private TangentManager tangentObj;

    private bool isStart = false;
    private Vector2 axis;

    public float speed;
    public float gravity;
    private float g;
    private TangentManager tan;
    private GameObject hitObj;

    void Start()
    {
        tan = tangentObj.GetComponent<TangentManager>();
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

   

    void PlayerMove()
    {
        playerObj.transform.position += new Vector3(transform.right.x * speed, transform.right.y * (speed + g), 0);
        if (transform.right.y > 0) g -= gravity;//y�����Ȃ猸��
        else g += gravity;//���Ȃ����

        if (speed < g)//y�̓������~�܂�Ɨ�����
        {
            Vector2 gravityAxis = new Vector2(1, transform.position.y);
            transform.RotateAround(playerObj.transform.position, gravityAxis, 180.0f);
        }
    }

    void PlayerReflection()
    {
        transform.right = hitObj.transform.position - this.gameObject.transform.position;//���������I�u�W�F�N�g�̕�������
        axis = tan.Line(playerObj.transform.position, hitObj.gameObject.transform.position);//�ڐ��̐���
        transform.RotateAround(playerObj.transform.position, axis, 180.0f);//�ڐ������ɉ�]
        g = 0;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "circle")
        {
            hitObj = other.gameObject;
            PlayerReflection();
        }

        //isStart=false;
    }

   
}
