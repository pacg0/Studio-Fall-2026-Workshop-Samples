using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;
enum TowerType
{
    None,
    Basic,
    Spread,
    Shotgun,
    Freeze,
    Slow
}
public class UIManager : MonoBehaviour
{
    TowerType selectedTower = TowerType.None;
    [SerializeField] GameObject ghost;
    [SerializeField] Tilemap placeable;
    bool canPlace = false;

    [Header("Tower Prefabs")]
    [SerializeField] Tower basicPrefab;
    [SerializeField] Tower spreadPrefab;
    [SerializeField] Tower shotgunPrefab;
    [SerializeField] Tower freezePrefab;
    [SerializeField] Tower slowPrefab;

    TDController controller;


    private void Start()
    {
        controller = GetComponent<TDController>();
    }

    void Update()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        canPlace = placeable.HasTile(placeable.WorldToCell(p));
        if (selectedTower != TowerType.None)
        {
            ghost.transform.position = p;
            if (!canPlace)
            {
                ghost.GetComponent<SpriteRenderer>().color = new Color(1,0,0,0.6f);
            }
            else
            {
                ghost.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.6f);
            }
        }
    }

    public void SelectTower(int towerType)
    {
        selectedTower = (TowerType)towerType;
        float range = GetTowerPrefab(selectedTower).attackRange;
        Debug.Log("Selected Tower: " + selectedTower);
        ghost.transform.localScale = new Vector3(range,range,1);
        ghost.SetActive(true);
    }

    public void PlaceTower(InputAction.CallbackContext context)
    {
        
        if(selectedTower != TowerType.None)
        {
            ghost.SetActive(false);
            Tower t = GetTowerPrefab(selectedTower);
            
            if (canPlace)
            {
                if (controller.TrySubtractMoney(t.cost))
                {
                    Vector3 p = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                    Instantiate(t, p, Quaternion.identity);
                }
            }
            selectedTower = TowerType.None;
        }
    }

    Tower GetTowerPrefab(TowerType t)
    {
        switch (t)
        {

            case TowerType.Basic:
                return (basicPrefab);
            case TowerType.Spread:
                return (spreadPrefab);
            case TowerType.Shotgun:
                return (shotgunPrefab);
            case TowerType.Freeze:
                return (freezePrefab);
            case TowerType.Slow:
                return (slowPrefab);
            default:
                return null;
        }
    }
}
