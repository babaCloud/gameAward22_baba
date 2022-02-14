using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangentContolloer : MonoBehaviour
{
    [SerializeField]
    private LineRenderer line;
    //[SerializeField]
    //private GameObject circle;

    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 clickPos;
    void Start()
    {

    }


    void Update()
    {
        Click();
        //Line();
    }

    void Click()
    {
        Vector3 position = Input.mousePosition;
        position.z = 10;//ScreenToWorldPoint�ɕϊ�����Ƃ��Ƀo�O��̂�
        clickPos = Camera.main.ScreenToWorldPoint(position);
    }

    public Vector2 Line(Vector2 setten,GameObject circle)
    {
        //���S����ړ_�܂ł̋���
        float dis = Mathf.Pow(setten.x - circle.transform.position.x, 2) +
            Mathf.Pow(setten.y - circle.transform.position.y, 2);
        dis = Mathf.Sqrt(dis);

        Vector2 circlePos = new Vector2(setten.x - circle.transform.position.x,
                            setten.y - circle.transform.position.y);

        //�ڐ��̎Z�o
        float startPosx = circle.transform.position.x - dis;
        float endPosx = circle.transform.position.x + dis;
        float startPosy = -(startPosx * circlePos.x) / circlePos.y;
        float endPosy = -(endPosx * circlePos.x) / circlePos.y;
        startPos = new Vector2(startPosx, startPosy) + setten;
        endPos = new Vector2(endPosx, endPosy) + setten;

        //�`��
        line.SetPosition(0, startPos);
        line.SetPosition(1, endPos);

        return startPos-endPos;
    }
}
