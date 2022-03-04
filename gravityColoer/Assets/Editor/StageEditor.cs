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
    /// ウィンドウを開いたときにファイル内にあるScriptableObjectを取得するメソッド
    /// </summary>
    private void startObjectRead()
    {
        //CardDataを持つScriptableObjectを検索
        var guids = AssetDatabase.FindAssets("t:StageData", null);
        //見つかった分ScriptableObjectのパスを取得
        foreach (var guid in guids)
        {
            //"Assets/StageData/test.asset"の形にパスを変換"
            string fPath = AssetDatabase.GUIDToAssetPath(guid);

            //stageに取得したパスのStageData型を入れる
            stage = AssetDatabase.LoadAssetAtPath<StageData>(fPath);

            stageDataList.Add(stage);
        }
    }

 
    private void LookList()
    {
        reorderableList = new ReorderableList(
            elements: stageDataList,    //要素
            elementType: typeof(StageData), //要素の種類
            draggable: true,           //ドラッグして要素を入れ替えられるか
            displayHeader: false,           //ヘッダーを表示するか
            displayAddButton: false,           //要素追加用の+ボタンを表示するか
            displayRemoveButton: false            //要素削除用の-ボタンを表示するか
         );

        reorderableList.onSelectCallback = list =>
        {
            //選択した要素番号を取得
            int selectNum = list.index;
            stageData = stageDataList[selectNum];

            stageDataEditor = GetWindow<StageDataEditor>();
        };
    }
}
