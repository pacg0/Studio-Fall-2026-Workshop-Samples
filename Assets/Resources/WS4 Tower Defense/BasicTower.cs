using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BasicTower : Tower
{
    GameObject currTarget;
    void Start()
    {
        InvokeRepeating("Shoot", 0, attackSpeed);
    }

    protected override void Shoot()
    {
        if (EnemiesInRange())
        {
            if (currTarget == null)
            {
                currTarget = FindEnemy();
            }
            RotateTowards(currTarget);
            Instantiate(projectile,transform.position,transform.rotation);
        }
    }
}
