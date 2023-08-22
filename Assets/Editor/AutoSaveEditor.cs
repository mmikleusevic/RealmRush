using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class AutoSaveEditor
{
    static AutoSaveEditor()
    {
        EditorApplication.playModeStateChanged += SaveOnPlay;
    }

    private static void SaveOnPlay(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            Debug.Log("Auto-saving...");
            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
        }
    }
}
