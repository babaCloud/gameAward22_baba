using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatStageManager : MonoBehaviour
{
    [Header("変更するステージ"), SerializeField]
    private StageData stageData;

    [Header("ステージデータが必要なスクリプト"), SerializeField]
    private CubeCreatManager cubeCreatManager;
    [SerializeField]
    private WallCreatManager wallCreatManager;

    [Header("UI"), SerializeField]
    private Text stageName;

    private void Awake()
    {
        cubeCreatManager.stageData = stageData;
        wallCreatManager.stageData = stageData;
        stageName.text = stageData.stageName;
    }
}
