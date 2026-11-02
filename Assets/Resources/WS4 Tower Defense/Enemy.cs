using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 3;

    //movement
    [SerializeField] private float moveSpeed = 5f;
    private Path pathScript;
    private List<Transform> assignedPathNodes;
    private float totalPathLength;
    private float distanceTraveled = 0f;
    [SerializeField] private bool takeNode8Branch = false;
    [Range(0f, 1f)] [SerializeField] private float progressU = 0f;

    void Start()
    {
        //find path object
        pathScript = FindFirstObjectByType<Path>();

        //choose end path to take, calculate length
        takeNode8Branch = Random.value > 0.5f;
        assignedPathNodes = pathScript.GetPathNodes(takeNode8Branch);
        totalPathLength = pathScript.GetPathLength(assignedPathNodes);

        //go to starting position
        if (assignedPathNodes.Count > 0 && assignedPathNodes[0] != null)
        {
            transform.position = assignedPathNodes[0].position;
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }

        if (assignedPathNodes == null || totalPathLength <= 0f) return;

        //go forward at constant speed
        distanceTraveled += moveSpeed * Time.deltaTime;

        //calculate progress
        progressU = Mathf.Clamp01(distanceTraveled / totalPathLength);

        int currentSegment;
        Vector3 targetPosition = pathScript.GetPointAtDistance(assignedPathNodes, distanceTraveled, out currentSegment);

        //move
        transform.position = targetPosition;

        //rotate direction along path
        // if (currentSegment < assignedPathNodes.Count - 1 && assignedPathNodes[currentSegment + 1] != null)
        // {
        //     Vector3 nextNodePos = assignedPathNodes[currentSegment + 1].position;
        //     Vector2 direction = (nextNodePos - transform.position);
            
        //     if (direction != Vector2.zero)
        //     {
        //         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //         Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        //         transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, moveSpeed * Time.deltaTime);
        //     }
        // }

        //check if we reached the end
        if (distanceTraveled >= totalPathLength)
        {
            OnReachEnd();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        if (other.CompareTag("Projectile"))
        {
            Projectile proj = other.GetComponent<Projectile>();
            if (proj != null)
            {
                health -= proj.GetDamage();
                //Debug.Log("Ouch");
            }
            
            Destroy(other.gameObject);
        }
    }

    private void OnReachEnd()
    {
        Destroy(gameObject);
        //do some amount of damage to lives
    }
}
