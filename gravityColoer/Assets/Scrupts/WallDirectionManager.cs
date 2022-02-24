using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDirectionManager : MonoBehaviour
{
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

    public string[] matName;

    private void Awake()
    {
        for(int i = 0; i < matName.Length; i++)
        {
            if (this.gameObject.GetComponent<MeshRenderer>().material.name == matName[i])
            {
                SetColorNum(i);
            }
        }
        
    }

    /// <summary>
    /// �F�ԍ��ݒ�
    /// </summary>
    /// <param name="num"></param>
    public void SetColorNum(int num)
    {
        colorNum = num;
    }

    /// <summary>
    /// �ʒu�ƐF�̒l��Ԃ�
    /// </summary>
    /// <returns></returns>
    public Wall GetWallDirectionColor()
    {
        return new Wall(transform.position, colorNum);
    }
}
