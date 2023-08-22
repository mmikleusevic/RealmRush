using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    private void OnMouseOver()
    {
        if (isPlaceable)
        {
            Debug.Log($"position: {transform.name}");
        }
    }
}
