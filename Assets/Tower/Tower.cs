using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 25;

    public bool CreateTower(Tower towerPrefab, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null) return false;

        if (bank.CurrentBalance >= cost)
        {
            bank.Withdraw(cost);

            Instantiate(towerPrefab, position, Quaternion.identity);

            return true;
        }

        return false;
    }
}
