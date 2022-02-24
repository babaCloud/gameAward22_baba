using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;
    [SerializeField]
    private GameObject arrowObj;
    [SerializeField]
    private TangentManager tangentObj;
    [SerializeField]
    private EdgeManager edgeObj;
    [SerializeField]
    private GameObject line_debug;

    [SerializeField]
    private GameObject kugi;
    [SerializeField]
    private GameObject balloon;
    [SerializeField]
    private GameObject cushion;
    [SerializeField]
    private GameObject plan;

    [SerializeField]
    private AudioSource SE;
    [SerializeField]
    private AudioClip normalBouncinessSE;

    private bool isStart = false;//クリックしたらスタート
    private Vector2 axis;//反射するときに使う軸

    public float speed;//1フレームあたり何ｍ動くか
    private float s;

    public float gravity;//重力加速度
    private float g;//実際の重力
    private float speedX;

    public float normal_bounciness;//普通の反射係数
    public float balloon_bounciness;//すごく跳ね返る反射係数
    public float cushin_bounciness;//衝撃吸収の反射係数

    private Vector2[] position;
    private Vector2 startPos;

    #region デバッグ用変数
    private GameObject obj;
    private LineRenderer line;
    private int vertexIndex;
    private Vector3[] vertex= {new Vector3(0,0,0) };
    private float time;
    #endregion

    void Start()
    {
        position = new Vector2[2];
        gravity /= 1000;
        startPos = playerObj.transform.position;
    }


    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStart = true;
        }

        if (isStart)
        {
            PlayerMove();
        }

        PlayerArrow();

        Debug_TypeSwitching();
        Debug_Line();

    }


    void Debug_TypeSwitching()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    kugi.SetActive(true);
        //    balloon.SetActive(false);
        //    cushion.SetActive(false);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    kugi.SetActive(false);
        //    balloon.SetActive(true);
        //    cushion.SetActive(false);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    kugi.SetActive(false);
        //    balloon.SetActive(false);
        //    cushion.SetActive(true);
        //}

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            playerObj.transform.position = startPos;
        }
    }

    void Debug_Line()
    {        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            obj = Instantiate(line_debug);
            line=line_debug.GetComponent<LineRenderer>();
            vertexIndex = 0;
            vertex[0] = startPos;
        }
        if (isStart)
        {
            vertexIndex++;
            Array.Resize(ref vertex, vertexIndex+1);
            vertex[vertexIndex] = playerObj.transform.position;;
            obj.GetComponent<LineRenderer>().SetVertexCount(vertexIndex);
            obj.GetComponent<LineRenderer>().SetPositions(vertex);
        }
        
    }

    void PlayerArrow()
    {
        if (!isStart)
        {
            arrowObj.SetActive(true);
            playerObj.transform.localEulerAngles -= new Vector3(0, 0, 0.1f);
        }
        else
        {
            arrowObj.SetActive(false);
        }
    }

    /// <summary>
    /// ballの動き
    /// </summary>
    void PlayerMove()
    {
        position[0] = position[1];
      
        playerObj.transform.position += 
            new Vector3(transform.right.x * speed, transform.right.y * (speed + g), 0);

        if (transform.right.y > 0) g -= gravity;//yが正なら減速
        else g += gravity;//負なら加速

        position[1] = new Vector2(transform.position.x,transform.position.y);
    }

    /// <summary>
    /// ballの反射(向き変えるだけ)
    /// </summary>
    void PlayerReflection()
    {
        transform.right = position[1] - position[0];//入射角=反射角
        transform.RotateAround(playerObj.transform.position, axis, 180.0f);//接線を軸に回転  
        g = 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //球
        if (collision.gameObject.tag == kugi.gameObject.tag)
        {
            axis = tangentObj.Line(playerObj.transform.position, collision.gameObject.gameObject.transform.position);//接線の生成
            PlayerReflection();
            g = normal_bounciness - speed;
        }
        if (collision.gameObject.tag == balloon.gameObject.tag)
        {
            axis = tangentObj.Line(playerObj.transform.position, collision.gameObject.gameObject.transform.position);//接線の生成
            PlayerReflection();
            g = balloon_bounciness - speed;
        }
        if (collision.gameObject.tag ==cushion.gameObject.tag)
        {
            axis = tangentObj.Line(playerObj.transform.position, collision.gameObject.gameObject.transform.position);//接線の生成
            PlayerReflection();
            g = cushin_bounciness - speed;
            transform.right = new Vector2(0,transform.right.y) ;
        }

        //面
        if (collision.gameObject.tag == "up")
        {           
            axis = edgeObj.UpWorldPosition(collision.transform.parent.gameObject);
            PlayerReflection();

        }
        if (collision.gameObject.tag == "down")
        {
            axis = edgeObj.DownWorldPosition(collision.transform.parent.gameObject);
            PlayerReflection();

        }
        if (collision.gameObject.tag == "left")
        {
            axis = edgeObj.LeftWorldPosition(collision.transform.parent.gameObject);
            PlayerReflection();

        }
        if (collision.gameObject.tag == "right")
        {
            axis = edgeObj.RightWorldPosition(collision.transform.parent.gameObject);
            PlayerReflection();

        }

    }
  

}
