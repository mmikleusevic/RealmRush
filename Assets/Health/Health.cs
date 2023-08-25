using System.Collections;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    int maxHealth = 20;
    int currentHealth;
    int waitForSeconds = 1;

    [SerializeField] TextMeshProUGUI displayHealth;
    [SerializeField] TextMeshProUGUI displayLevelText;

    SceneManagerScript SceneManagerScript;


    void Awake()
    {
        currentHealth = maxHealth;
        SceneManagerScript = SceneManagerScript.GetInstance();
        UpdateHealthDisplay();
    }

    public void DecreaseHealth(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            GameOverText();
            Invoke("ReloadLevelOnDeath",waitForSeconds);
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

    void ReloadLevelOnDeath()
    {
        SceneManagerScript.ManageScene(Scene.Reload);
    }

    void UpdateHealthDisplay()
    {
        displayHealth.text = "Health: " + currentHealth;
    }

    void GameOverText() 
    {
        displayLevelText.text = "Game Over";
    }
}
