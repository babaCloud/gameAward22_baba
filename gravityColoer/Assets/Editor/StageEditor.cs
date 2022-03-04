using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

public class StageEditor : EditorWindow
{
    private List<StageData> stageDataList = new List<StageData>();
    private StageData stage;
    public static StageData stageData;
    private ReorderableList reorderableList;

    private StageDataEditor stageDataEditor;

    [MenuItem("GameControlMenu/StageData")]
    static void Open()
    {
        var window = GetWindow<StageEditor>();
        window.titleContent = new GUIContent("StageData");
    }

    private void OnEnable()
    {
        stage = new StageData();
        startObjectRead();
        LookList();

    }

    private void OnGUI()
    {
        reorderableList.DoLayoutList();       
    }

    /// <summary>
    /// �E�B���h�E���J�����Ƃ��Ƀt�@�C�����ɂ���ScriptableObject���擾���郁�\�b�h
    /// </summary>
    private void startObjectRead()
    {
        //CardData������ScriptableObject������
        var guids = AssetDatabase.FindAssets("t:StageData", null);
        //����������ScriptableObject�̃p�X���擾
        foreach (var guid in guids)
        {
            //"Assets/StageData/test.asset"�̌`�Ƀp�X��ϊ�"
            string fPath = AssetDatabase.GUIDToAssetPath(guid);

            //stage�Ɏ擾�����p�X��StageData�^������
            stage = AssetDatabase.LoadAssetAtPath<StageData>(fPath);

            stageDataList.Add(stage);
        }
    }

 
    private void LookList()
    {
        reorderableList = new ReorderableList(
            elements: stageDataList,    //�v�f
            elementType: typeof(StageData), //�v�f�̎��
            draggable: true,           //�h���b�O���ėv�f�����ւ����邩
            displayHeader: false,           //�w�b�_�[��\�����邩
            displayAddButton: false,           //�v�f�ǉ��p��+�{�^����\�����邩
            displayRemoveButton: false            //�v�f�폜�p��-�{�^����\�����邩
         );

        reorderableList.onSelectCallback = list =>
        {
            //�I�������v�f�ԍ����擾
            int selectNum = list.index;
            stageData = stageDataList[selectNum];

            stageDataEditor = GetWindow<StageDataEditor>();
        };
    }
}
