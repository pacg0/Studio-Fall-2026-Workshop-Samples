using UnityEngine;

public class Shark : MonoBehaviour
{
    Enemy selfEnemy;
    private int myCurrentHealth;
    private int interval;

    [SerializeField] int maxInterval = 200;
    [SerializeField] float multiplier = 1.1f;

    
    void Start()
    {
        selfEnemy = GetComponent<Enemy>();
        //myCurrentHealth = selfEnemy.GetHealth();
        //interval = maxInterval; 
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //check my health
        //if my health != myCurrenthealth
        //  interval = maxInterval;
        //else if (interval <=0)
        //  increase my speed by multipier

        //interval -= 1
    }
}
