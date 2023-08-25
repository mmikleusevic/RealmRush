using System.Collections;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayHealth;
    [SerializeField] TextMeshProUGUI displayLevelText;

    int maxHealth = 20;
    int currentHealth;
    int waitForSeconds = 2;

    GameManager gameManager;
    SceneManagerScript sceneManagerScript;

    void Start()
    {
        currentHealth = maxHealth;
        gameManager = GameManager.GetInstance();
        sceneManagerScript = SceneManagerScript.GetInstance();
        UpdateHealthDisplay();
    }

    public void DecreaseHealth(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            GameOver();
        }

        UpdateHealthDisplay();
    }

    public void IncreaseHealth(int healthPoints)
    {
        int newHealth = currentHealth + healthPoints;

        if (newHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healthPoints;
        }
        UpdateHealthDisplay();
    }

    void UpdateHealthDisplay()
    {
        displayHealth.text = "Health: " + currentHealth;
    }

    void GameOver() 
    {
        displayLevelText.text = "Game Over";
        StartCoroutine(ReloadLevelOnDeath());
    }

    IEnumerator ReloadLevelOnDeath()
    {
        gameManager.PauseScreen();
        yield return new WaitForSecondsRealtime(waitForSeconds);
        gameManager.UnpauseScreen();

        sceneManagerScript.ManageScene(Scene.Reload);
    }
}
