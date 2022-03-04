using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatStageManager : MonoBehaviour
{
    [Header("�ύX����X�e�[�W"), SerializeField]
    private StageData stageData;

    [Header("�X�e�[�W�f�[�^���K�v�ȃX�N���v�g"), SerializeField]
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
