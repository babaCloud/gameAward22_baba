using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeManager : MonoBehaviour
{
    /// <summary>
    /// 上面のベクトル取得
    /// </summary>
    /// <param name="edgeObj"></param>
    /// <returns></returns>
    public Vector2 UpWorldPosition(GameObject edgeObj)
    {
        Vector2 axis;

        Vector3 vec0 = edgeObj.transform.position + new Vector3(0, edgeObj.transform.localScale.y * 0.5f, 0);
        Vector3 vec1 = edgeObj.transform.position + new Vector3(0, edgeObj.transform.localScale.y * 0.5f, 0);
        vec0.x += edgeObj.transform.localScale.x * 0.5f * Mathf.Cos(edgeObj.transform.localEulerAngles.z / 180.0f * Mathf.PI);
        vec0.y += edgeObj.transform.localScale.x * 0.5f * Mathf.Sin(edgeObj.transform.localEulerAngles.z / 180.0f * Mathf.PI);
        vec1.x -= edgeObj.transform.localScale.x * 0.5f * Mathf.Cos(edgeObj.transform.localEulerAngles.z / 180.0f * Mathf.PI);
        vec1.y -= edgeObj.transform.localScale.x * 0.5f * Mathf.Sin(edgeObj.transform.localEulerAngles.z / 180.0f * Mathf.PI);

        //Debug.Log("up" + vec0 + "," + vec1);

        axis = vec1 - vec0;
        return axis;
    }

    /// <summary>
    /// 下面のベクトル取得
    /// </summary>
    /// <param name="edgeObj"></param>
    /// <returns></returns>
    public Vector2 DownWorldPosition(GameObject edgeObj)
    {
        Vector2 axis;

        Vector3 vec0 = edgeObj.transform.position - new Vector3(0, edgeObj.transform.localScale.y * 0.5f, 0);
        Vector3 vec1 = edgeObj.transform.position - new Vector3(0, edgeObj.transform.localScale.y * 0.5f, 0);
        vec0.x += edgeObj.transform.localScale.x * 0.5f * Mathf.Cos(edgeObj.transform.localEulerAngles.z / 180.0f * Mathf.PI);
        vec0.y += edgeObj.transform.localScale.x * 0.5f * Mathf.Sin(edgeObj.transform.localEulerAngles.z / 180.0f * Mathf.PI);
        vec1.x -= edgeObj.transform.localScale.x * 0.5f * Mathf.Cos(edgeObj.transform.localEulerAngles.z / 180.0f * Mathf.PI);
        vec1.y -= edgeObj.transform.localScale.x * 0.5f * Mathf.Sin(edgeObj.transform.localEulerAngles.z / 180.0f * Mathf.PI);

        //Debug.Log("down" + vec0 + "," + vec1);

        axis = vec1 - vec0;
        return axis;
    }

    /// <summary>
    /// 左面のベクトル取得
    /// </summary>
    /// <param name="edgeObj"></param>
    /// <returns></returns>
    public Vector2 LeftWorldPosition(GameObject edgeObj)
    {
        Vector2 axis;

        //線の中央
        Vector3 vec0 = edgeObj.transform.position;
        Vector3 vec1;
        vec0.x -= edgeObj.transform.localScale.x * 0.5f * Mathf.Cos(edgeObj.transform.localEulerAngles.z / 180.0f * Mathf.PI);
        vec0.y -= edgeObj.transform.localScale.x * 0.5f * Mathf.Sin(edgeObj.transform.localEulerAngles.z / 180.0f * Mathf.PI);
        vec1 = vec0;

        //それぞれ
        vec0.x += edgeObj.transform.localScale.y * 0.5f * Mathf.Cos((edgeObj.transform.localEulerAngles.z + 90) / 180.0f * Mathf.PI);
        vec0.y += edgeObj.transform.localScale.y * 0.5f * Mathf.Sin((edgeObj.transform.localEulerAngles.z + 90) / 180.0f * Mathf.PI);
        vec1.x -= edgeObj.transform.localScale.y * 0.5f * Mathf.Cos((edgeObj.transform.localEulerAngles.z + 90) / 180.0f * Mathf.PI);
        vec1.y -= edgeObj.transform.localScale.y * 0.5f * Mathf.Sin((edgeObj.transform.localEulerAngles.z + 90) / 180.0f * Mathf.PI);

        //Debug.Log("left" + vec0 + "," + vec1);

        axis = vec1 - vec0;
        return axis;
    }

    /// <summary>
    /// 右面のベクトル取得
    /// </summary>
    /// <param name="edgeObj"></param>
    /// <returns></returns>
    public Vector2 RightWorldPosition(GameObject edgeObj)
    {
        Vector2 axis;

        //線の中央
        Vector3 vec0 = edgeObj.transform.position;
        Vector3 vec1;
        vec0.x += edgeObj.transform.localScale.x * 0.5f * Mathf.Cos(edgeObj.transform.localEulerAngles.z / 180.0f * Mathf.PI);
        vec0.y += edgeObj.transform.localScale.x * 0.5f * Mathf.Sin(edgeObj.transform.localEulerAngles.z / 180.0f * Mathf.PI);
        vec1 = vec0;

        //それぞれ
        vec0.x += edgeObj.transform.localScale.y * 0.5f * Mathf.Cos((edgeObj.transform.localEulerAngles.z + 90) / 180.0f * Mathf.PI);
        vec0.y += edgeObj.transform.localScale.y * 0.5f * Mathf.Sin((edgeObj.transform.localEulerAngles.z + 90) / 180.0f * Mathf.PI);
        vec1.x -= edgeObj.transform.localScale.y * 0.5f * Mathf.Cos((edgeObj.transform.localEulerAngles.z + 90) / 180.0f * Mathf.PI);
        vec1.y -= edgeObj.transform.localScale.y * 0.5f * Mathf.Sin((edgeObj.transform.localEulerAngles.z + 90) / 180.0f * Mathf.PI);

        //Debug.Log("right" + vec0 + "," + vec1);

        axis = vec1 - vec0;
        return axis;
    }
}
