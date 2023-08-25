using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class SceneManagerScript : ScriptableObject
{
    static SceneManagerScript sceneManagerScript = null;

    public static SceneManagerScript GetInstance()
    {
        if (sceneManagerScript == null)
        {
            sceneManagerScript = CreateInstance<SceneManagerScript>();
        }
        return sceneManagerScript;
    }

    public void ManageScene(Scene scene)
    {
        if (scene == Scene.Next)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
        else if (scene == Scene.Reload)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}

public enum Scene
{
    Reload,
    Next
}
