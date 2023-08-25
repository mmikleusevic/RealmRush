using System.IO;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class GameManager : ScriptableObject
{
    const string Panel = "Panel";

    private static GameManager instance;

    private static GameObject panel;

    private static bool isPaused = false;

    public static bool IsPaused { get { return isPaused; } }

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            instance = CreateInstance<GameManager>();
        }

        return instance;
    }

    public void PauseScreen()
    {
        isPaused = true;
        FindPanel();

        panel.SetActive(isPaused);
        Time.timeScale = 0f;
    }

    public void UnpauseScreen()
    {
        isPaused = false;
        FindPanel();

        panel.SetActive(isPaused);
        Time.timeScale = 1f;
    }

    void FindPanel()
    {
        if (panel == null)
        {
            Transform canvas = FindObjectOfType<Canvas>().GetComponentInChildren<Transform>();

            foreach (Transform transform in canvas)
            {
                if (transform.tag == Panel)
                {
                    panel = transform.gameObject;
                    return;
                }
            }
        }
    }
}
