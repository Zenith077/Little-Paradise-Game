using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class LoadInitOnPlayInEditor : MonoBehaviour
{
    static LoadInitOnPlayInEditor()
    {
        EditorApplication.playModeStateChanged += ModeChanged;
    }


    [MenuItem("Edit/Play From Prelaunch Scene %0")]
    public static void PlayFromPrelaunchScene()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
            return;
        }
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/QuickInitialize.unity", OpenSceneMode.Additive);
        EditorApplication.isPlaying = true;
    }

    static void ModeChanged(PlayModeStateChange playModeState)
    {
        if (playModeState == PlayModeStateChange.EnteredEditMode)
        {
            EditorSceneManager.CloseScene(SceneManager.GetSceneByBuildIndex(1), true);
            Debug.Log("Entered edit mode, closing the initilization Scene");
        }
    }


}
