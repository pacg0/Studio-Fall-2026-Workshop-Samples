using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackRange;
    public float attackSpeed;
    public int cost;

    //public void FindEnemy()
    //{
    //    GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");

    //    GameObject nearestTarget = null;
    //    float closestDistance = attackRange;

    //    foreach (GameObject target in targets)
    //    {
    //        float distance = Vector2.Distance(transform.position, target.transform.position);

    //        if (distance < closestDistance)
    //        {
    //            closestDistance = distance;
    //            nearestTarget = target;
    //        }
    //    }

    //    if (nearestTarget != null)
    //    {
    //        Vector2 direction = nearestTarget.transform.position - transform.position;

    //        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    //        transform.rotation = Quaternion.Euler(0, 0, angle);
    //    }
    //}

    public virtual void Shoot(GameObject target) { }

}
