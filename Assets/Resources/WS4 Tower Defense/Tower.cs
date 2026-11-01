using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float attackRange; 
    [SerializeField] private float attackSpeed; 
    [SerializeField] float cost; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindEnemy()
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
            Vector2 direction = nearestTarget.transform.position - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
