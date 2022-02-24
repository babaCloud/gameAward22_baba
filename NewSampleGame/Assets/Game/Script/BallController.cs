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

    private bool isStart = false;//�N���b�N������X�^�[�g
    private Vector2 axis;//���˂���Ƃ��Ɏg����

    public float speed;//1�t���[�������艽��������
    private float s;

    public float gravity;//�d�͉����x
    private float g;//���ۂ̏d��
    private float speedX;

    public float normal_bounciness;//���ʂ̔��ˌW��
    public float balloon_bounciness;//���������˕Ԃ锽�ˌW��
    public float cushin_bounciness;//�Ռ��z���̔��ˌW��

    private Vector2[] position;
    private Vector2 startPos;

    #region �f�o�b�O�p�ϐ�
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
    /// ball�̓���
    /// </summary>
    void PlayerMove()
    {
        position[0] = position[1];
      
        playerObj.transform.position += 
            new Vector3(transform.right.x * speed, transform.right.y * (speed + g), 0);

        if (transform.right.y > 0) g -= gravity;//y�����Ȃ猸��
        else g += gravity;//���Ȃ����

        position[1] = new Vector2(transform.position.x,transform.position.y);
    }

    /// <summary>
    /// ball�̔���(�����ς��邾��)
    /// </summary>
    void PlayerReflection()
    {
        transform.right = position[1] - position[0];//���ˊp=���ˊp
        transform.RotateAround(playerObj.transform.position, axis, 180.0f);//�ڐ������ɉ�]  
        g = 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //��
        if (collision.gameObject.tag == kugi.gameObject.tag)
        {
            axis = tangentObj.Line(playerObj.transform.position, collision.gameObject.gameObject.transform.position);//�ڐ��̐���
            PlayerReflection();
            g = normal_bounciness - speed;
        }
        if (collision.gameObject.tag == balloon.gameObject.tag)
        {
            axis = tangentObj.Line(playerObj.transform.position, collision.gameObject.gameObject.transform.position);//�ڐ��̐���
            PlayerReflection();
            g = balloon_bounciness - speed;
        }
        if (collision.gameObject.tag ==cushion.gameObject.tag)
        {
            axis = tangentObj.Line(playerObj.transform.position, collision.gameObject.gameObject.transform.position);//�ڐ��̐���
            PlayerReflection();
            g = cushin_bounciness - speed;
            transform.right = new Vector2(0,transform.right.y) ;
        }

        //��
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
