using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
#if UNITY_EDITOR
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(AdditionalMission))]
public class AdditionalMissionEditor : Editor
{
    private string[] tavbs;
    private int tabIndex = 0;

    public override void OnInspectorGUI()
    {

        ChevalierChef[] enumValues = (ChevalierChef[])Enum.GetValues(typeof(ChevalierChef));
        tavbs = new string[enumValues.Length];
        // Iterate over each enum value
        for(int i = 0; i < enumValues.Length; i++)
            tavbs[i] = enumValues[i].ToString();

        AdditionalMission addMission = (AdditionalMission)target;

        EditorGUILayout.BeginVertical();
        tabIndex = GUILayout.Toolbar(tabIndex, tavbs);
        EditorGUILayout.EndVertical();
        switch (tabIndex)
        {
            default:
                AddMissionPannel(enumValues[tabIndex], addMission);
                break;
        }


    }

    private void AddMissionPannel(ChevalierChef currChevalier, AdditionalMission target)
    {
        GUILayout.Label("Mission");
        target.mission[currChevalier] = EditorGUILayout.TextArea(target.mission[currChevalier], GUILayout.Height(100)); ;
    }
}
#endif