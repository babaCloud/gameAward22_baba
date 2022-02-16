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
        if (transform.right.y > 0) g -= gravity;//yが正なら減速
        else g += gravity;//負なら加速

        if (speed < g)//yの動きが止まると落ちる
        {
            Vector2 gravityAxis = new Vector2(1, transform.position.y);
            transform.RotateAround(playerObj.transform.position, gravityAxis, 180.0f);
        }
    }

    void PlayerReflection()
    {
        transform.right = hitObj.transform.position - this.gameObject.transform.position;//当たったオブジェクトの方向向く
        axis = tan.Line(playerObj.transform.position, hitObj.gameObject.transform.position);//接線の生成
        transform.RotateAround(playerObj.transform.position, axis, 180.0f);//接線を軸に回転
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
