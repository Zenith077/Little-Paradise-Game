using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DataUtils;

#if UNITY_EDITOR
[CustomEditor(typeof(EnemyData))]
public class EnemyDataInspector : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("A data container for Enemy Data", MessageType.Info);
        DrawDefaultInspector();

        EditorGUILayout.Separator();
        EnemyData script = (EnemyData)target;

        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("DEBUG MENU");
        if (GUILayout.Button("Add Default Stat Params"))
        {
            EnemyUtils.AddDefaultStatParams(script.baseStats);
            EnemyUtils.AddDefaultStatParams(script.activeStats);
        }
        if (GUILayout.Button("Add Default Battle Behaviour Types"))
        {
            EnemyUtils.AddDefaultBattleBehaviour(script.battleBehaviour);
        }
        if (GUILayout.Button("Reset Active Stats"))
        {
            EnemyUtils.SetStatsAtoB(script.baseStats, script.activeStats);
        }

        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("DANGEROUS DEBUG MENU");
        if (GUILayout.Button("Clear all Stats"))
        {
            EnemyUtils.ClearStatDictionary(script.baseStats);
            EnemyUtils.ClearStatDictionary(script.activeStats);
        }
        if (GUILayout.Button("Remove PAT"))
        {
            EnemyUtils.RemoveEntry(script.activeStats, "PAT");
        }
        if (GUILayout.Button("Increment PAT"))
        {
            float newVal = script.activeStats["PAT"] + 1;
            EnemyUtils.UpdateEntry(script.activeStats, "PAT", newVal);
        }
    }
}
#endif