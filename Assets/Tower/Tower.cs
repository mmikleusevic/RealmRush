using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 25;
    [SerializeField] float buildDelay = 2f;
    public int Cost { get { return cost; } }

    void Start()
    {
        StartCoroutine(Build());
    }

    public void CreateTower(Tower towerPrefab, Vector3 position)
    {
        Instantiate(towerPrefab, position, Quaternion.identity);
    }

    IEnumerator Build()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach(Transform grandChild in child)
            {
                grandChild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach (Transform grandChild in child)
            {
                grandChild.gameObject.SetActive(true);
            }
        }
    }
}
