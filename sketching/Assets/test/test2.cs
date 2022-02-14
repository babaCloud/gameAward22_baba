using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    [SerializeField]
    private LineRenderer line;
    [SerializeField]
    private GameObject circle;

    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 clickPos;
    void Start()
    {
        
    }

    
    void Update()
    {
        Click();
        Line();
    }

    void Click()
    {
        Vector3 position = Input.mousePosition;
        position.z = 10;//ScreenToWorldPointに変換するときにバグるので
        clickPos = Camera.main.ScreenToWorldPoint(position);
    }

    void Line()
    {
        //中心から接点までの距離
        float dis = Mathf.Pow(clickPos.x-circle.transform.position.x,2) + 
            Mathf.Pow(clickPos.y - circle.transform.position.y, 2);
        dis = Mathf.Sqrt(dis);

        Vector2 circlePos = new Vector2(clickPos .x- circle.transform.position.x,
                            clickPos.y-circle.transform.position.y);

        //接線の算出
        float startPosx = circle.transform.position.x - dis;
        float endPosx = circle.transform.position.x + dis;
        float startPosy = -(startPosx * circlePos.x) / circlePos.y;
        float endPosy = -(endPosx * circlePos.x) / circlePos.y;
        startPos = new Vector2(startPosx, startPosy)+clickPos;
        endPos = new Vector2(endPosx, endPosy)+clickPos;

        //描画
        line.SetPosition(0, startPos);
        line.SetPosition(1, endPos);
    }
}
