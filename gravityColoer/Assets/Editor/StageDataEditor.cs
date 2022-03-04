using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

public class StageDataEditor : EditorWindow
{
    public struct CubeColor
    {
        public Material colorName;
        public int colorCount;

        public CubeColor(Material colorName, int colorCount)
        {
            this.colorName = colorName;
            this.colorCount = colorCount;
        }
    }
    private List<CubeColor> cube;

    [MenuItem("GameControlMenu/1Stage")]
    static void Open()
    {
        var window = GetWindow<EditorWindow>();
        window.titleContent = new GUIContent("StageData");
    }

    private void OnEnable()
    {
        cube = new List<CubeColor>();
        cube.Clear();
        var cubeData = new CubeColor();
        cube.Add(cubeData);

        for (int i = 0; i < StageEditor.stageData.cubeData.Length; i++)
        {
            

        }

        
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("stageName", StageEditor.stageData.stageName);

        for (int i = 0; i < cube.Count; i++)
        {
            Debug.Log(cube[i].colorName.name + "" + cube[i].colorCount.ToString());
            EditorGUILayout.LabelField(cube[i].colorName.name, cube[i].colorCount.ToString());
        }



    }
}
