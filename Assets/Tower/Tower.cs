using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 25;
    public int Cost { get { return cost; } }

    public bool CreateTower(Tower towerPrefab, Vector3 position)
    {
        return Instantiate(towerPrefab, position, Quaternion.identity);
    }
}
