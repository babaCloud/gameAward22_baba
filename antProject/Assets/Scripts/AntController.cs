using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntController : MonoBehaviour
{
    [SerializeField]
    private LineRenderer load;

    private bool isStart = false;
    private int loadIndexCount;

    public float speed;// 1フレームで何メートル進むか
    private Vector2 loadPos;
    private float minSpan;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            loadIndexCount = 0;
            isStart = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isStart = true;
        }
        if (isStart)
        {
            MoveAnt();
        }
    }

    void MoveAnt()
    {
        transform.position = load.GetPosition(loadIndexCount);
        loadIndexCount++;
    }

    void SetLoadPos()
    {

    }
}
