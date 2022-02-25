using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCon : MonoBehaviour
{

    [SerializeField]
    private GameObject ball;

    private LineRenderer line;

    public float speed;

    void Start()
    {
        
    }

   
    void Update()
    {
       
        ball.transform.position += ball.transform.right*speed;
    }
    void hannsya()
    {
        Vector2 axis = new Vector2(line.GetPosition(0).x- line.GetPosition(1).x,
                        line.GetPosition(0).y - line.GetPosition(1).y);
        transform.RotateAround(ball.transform.position,axis,180.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "line")
        {

            line = collision.gameObject.GetComponent<LineRenderer>();
            hannsya();
        }
    }

    
}
