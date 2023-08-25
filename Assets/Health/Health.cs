using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    int maxHealth = 20;
    int currentHealth;
    int waitForSeconds = 1;

    SceneManagerScript SceneManagerScript;

    void Awake()
    {
        currentHealth = maxHealth;
        SceneManagerScript = SceneManagerScript.GetInstance();
    }

    public void DecreaseHealth(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Invoke("ReloadLevelOnDeath",waitForSeconds);
            Debug.Log("Game Over");
        }
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
    }

    void ReloadLevelOnDeath()
    {
        SceneManagerScript.ManageScene(Scene.Reload);
    }
}
