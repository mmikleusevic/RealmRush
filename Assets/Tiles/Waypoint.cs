using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceable;

    public bool IsPlaceable { get { return isPlaceable; } }

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            InstantiateObject();
            Debug.Log($"position: {transform.name}");
            isPlaceable = false;
        }
    }

    void InstantiateObject()
    {
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
    }
}
