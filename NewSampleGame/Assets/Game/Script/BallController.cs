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

    private bool isStart = false;//クリックしたらスタート
    private Vector2 axis;//反射するときに使う軸

    public float speed;//1フレームあたり何ｍ動くか
    public float gravity;//重力加速度
    private float g;//実際の重力

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
    /// ballの動き
    /// </summary>
    void PlayerMove()
    {
        position[0] = position[1];

        playerObj.transform.position += new Vector3(transform.right.x * speed, transform.right.y * (speed + g), 0);
        if (transform.right.y > 0) g -= gravity;//yが正なら減速
        else g += gravity;//負なら加速

        position[1] = new Vector2(transform.position.x,transform.position.y);
    }

    /// <summary>
    /// ballの反射(向き変えるだけ)
    /// </summary>
    void PlayerReflection()
    {              
        transform.RotateAround(playerObj.transform.position, axis, 180.0f);//接線を軸に回転
        g = 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //球
        if (collision.gameObject.tag == "circle")
        {
            transform.right = collision.gameObject.transform.position - this.gameObject.transform.position;//当たったオブジェクトの方向向く
            axis = tangentObj.Line(playerObj.transform.position, collision.gameObject.gameObject.transform.position);//接線の生成
            PlayerReflection();
        }

        //面
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
