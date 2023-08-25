using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class SceneManagerScript : ScriptableObject
{
    private static SceneManagerScript instance;

    public static SceneManagerScript GetInstance()
    {
        if (instance == null)
        {
            instance = CreateInstance<SceneManagerScript>();
        }

        return instance;
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
