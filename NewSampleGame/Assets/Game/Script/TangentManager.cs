using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangentManager : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 endPos;

    public Vector2 Line(Vector2 setten, Vector2 circle)
    {
        //’†S‚©‚çÚ“_‚Ü‚Å‚Ì‹——£
        float dis = Mathf.Pow(setten.x - circle.x, 2) +
            Mathf.Pow(setten.y - circle.y, 2);
        dis = Mathf.Sqrt(dis);

        Vector2 circlePos = new Vector2(setten.x - circle.x,
                            setten.y - circle.y);

        //Úü‚ÌZo
        float startPosx = circle.x - dis;
        float endPosx = circle.x + dis;
        float startPosy = -(startPosx * circlePos.x) / circlePos.y;
        float endPosy = -(endPosx * circlePos.x) / circlePos.y;
        startPos = new Vector2(startPosx, startPosy) + setten;
        endPos = new Vector2(endPosx, endPosy) + setten;

        return startPos - endPos;
    }
}
