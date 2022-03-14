using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDirectionManager : MonoBehaviour
{
    [System.Serializable]
    public struct Wall
    {
        public Vector2 pos;
        public int colorNum;

        public Wall(Vector2 pos, int colorNum)
        {
            this.pos = pos;
            this.colorNum = colorNum;
        }
    }
    private int colorNum;

    private StageManager stageManager;
    private GameData mapData;

    private void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        mapData = stageManager.GetGameData();
    }

    /// <summary>
    /// 色番号設定
    /// </summary>
    /// <param name="num"></param>
    public void SetColorNum(int num)
    {
        colorNum = num;
    }

    /// <summary>
    /// 位置と色の値を返す
    /// </summary>
    /// <returns></returns>
    public Wall GetWallDirectionColor()
    {
        Vector2 pos = transform.position.normalized;
        if (1 != Mathf.Abs(pos.x)) pos.x = 0;
        if (1 != Mathf.Abs(pos.y)) pos.y = 0;
        return new Wall(pos, colorNum);
    }
}
