using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;

    GridManager gridManager;
    Pathfinder pathfinder;
    Bank bank;

    Vector2Int coordinates = new Vector2Int();
    public bool IsPlaceable { get { return isPlaceable; } }

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
        bank = FindObjectOfType<Bank>();
    }

    void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown()
    {
        if (!bank || !towerPrefab || bank.CurrentBalance < towerPrefab.Cost) return;

        if (gridManager.GetNode(coordinates).isWalkable && !GameManager.IsPaused && !pathfinder.WillBlockPath(coordinates))
        {
            towerPrefab.CreateTower(towerPrefab, transform.position);

            bank.Withdraw(towerPrefab.Cost);

            gridManager.BlockNode(coordinates);
            pathfinder.NotifyReceivers();
        }
    }
}
