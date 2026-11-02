using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] public GameObject projectile;
    public float attackRange;
    public float attackSpeed;
    public int cost;

    public bool EnemiesInRange()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject target in targets)
        {
            float distance = Vector2.Distance(transform.position, target.transform.position);
            if (distance < attackRange)
            {
                return true;
            }
        }
        return false;
    }

    public GameObject FindEnemy()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject nearestTarget = null;
        float closestDistance = attackRange;

        foreach (GameObject target in targets)
        {
            float distance = Vector2.Distance(transform.position, target.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestTarget = target;
            }
        }

        if (nearestTarget != null)
        {
            RotateTowards(nearestTarget);
            return nearestTarget;
        }
        return null;
    }

    public void RotateTowards(GameObject go)
    {
        Vector2 direction = go.transform.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public virtual void Shoot() { }

}
