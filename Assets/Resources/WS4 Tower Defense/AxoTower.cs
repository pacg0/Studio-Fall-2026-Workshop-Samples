using UnityEngine;

public class AxoTower : MonoBehaviour
{
    Tower myTower;
    [SerializeField] GameObject myProjectile;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myTower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        //every myTower.attackspeed, attack()
    }

    void Attack()
    {
        myTower.FindEnemy();

        //instantiate projectile prefab
    }
}
