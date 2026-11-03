using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BasicTower : Tower
{
    GameObject currTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Shoot", 0, attackSpeed);
    }

    public override void Shoot()
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
