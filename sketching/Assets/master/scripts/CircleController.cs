using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField]
    private LineRenderer circleLine;
    [SerializeField]
    private PolygonCollider2D poly;

    public float r;
    private float radi;
    void Start()
    {
        Vector2[] points = new Vector2[circleLine.positionCount];
        int hoge = 360 / circleLine.positionCount;
        for (int i = 0; i < circleLine.positionCount; i++)
        {
            Vector3 circlePos = new Vector3(circleLine.transform.position.x + r * Mathf.Cos(radi / 180 * Mathf.PI),
                                circleLine.transform.position.y + r * Mathf.Sin(radi / 180 * Mathf.PI), 0);            
            points[i] = circlePos;
            circleLine.SetPosition(i, points[i]);
            radi += hoge;
        }

        poly.offset = -this.gameObject.transform.position;
        poly.points = points; 
    }
}
