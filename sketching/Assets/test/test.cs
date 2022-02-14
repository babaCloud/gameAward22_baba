using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    private LineRenderer circleLine;

    public float r;
    private float radi;
    void Start()
    {
        int hoge = 360 / circleLine.positionCount;
        for (int i = 0; i < circleLine.positionCount; i++)
        {
            Vector3 circlePos = new Vector3(circleLine.transform.position.x + r * Mathf.Cos(radi / 180 * Mathf.PI),
                                circleLine.transform.position.y + r * Mathf.Sin(radi / 180 * Mathf.PI), 0);
            circleLine.SetPosition(i, circlePos);
            radi += hoge;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
