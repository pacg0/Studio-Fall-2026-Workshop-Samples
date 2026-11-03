using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpreadTower : Tower
{
    void Start()
    {
        InvokeRepeating("Shoot", 0, attackSpeed);
    }

    public override void Shoot()
    {
        if (EnemiesInRange())
        {
            for(int angle = 0; angle <= 360; angle += 45)
            {
                Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, angle));
            }
        }
    }
}
