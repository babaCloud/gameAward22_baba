using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] stageButton;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            for(int i = 0; i < stageButton.Length; i++)
            {
                //�o�Ă��Ȃ��Ƃ���Əo��
                if (!stageButton[i].activeSelf)
                {
                    stageButton[i].SetActive(true);
                    return;
                }

                //�S���o�Ă���Ώ���
                if (i == stageButton.Length - 1)
                {
                    for (int j = 0; j < stageButton.Length; j++)
                    {
                        stageButton[j].SetActive(false);
                    }
                }
            }
        }
    }
}
