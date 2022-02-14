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
                //出ていないところと出す
                if (!stageButton[i].activeSelf)
                {
                    stageButton[i].SetActive(true);
                    return;
                }

                //全部出ていれば消す
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
