using UnityEngine;
using UnityEngine.InputSystem;
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


    private void Start()
    {
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
        Debug.Log("Selected Tower: " + selectedTower);
        ghost.SetActive(true);
    }

    public void PlaceTower(InputAction.CallbackContext context)
    {
        
        if(selectedTower != TowerType.None)
        {
            

            ghost.SetActive(false);
            selectedTower = TowerType.None;

            if (canPlace)
            {
                Vector3 p = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            }
        }


        // if (!context.performed)
        //     return;

        // if (selectedTower != TowerType.None)
        // {
        //     Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //     GameObject towerPrefab = GetTowerPrefab(selectedTower);

        //     if (towerPrefab != null)
        //     {
        //         Instantiate(towerPrefab, mousePosition, Quaternion.identity);
        //         Debug.Log("Placed Tower: " + selectedTower);
        //     }
        // }
    }

    //GameObject GetTowerPrefab(TowerType t)
    //{
    //    switch (t)
    //    {
    //        case TowerType.None:
    //            return null;
    //        case TowerType.Basic:
    //        case TowerType.Spread:
    //        case TowerType.Shotgun:
    //        case TowerType.Freeze:
    //        case TowerType.Slow:
    //    }
    //}
}
