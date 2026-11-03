using System.Collections;
using System.Diagnostics.Metrics;
using UnityEngine; 

public class FlappyController : MonoBehaviour
{
    //declaring variables
    public int _score;

    [SerializeField] FlappyObstacle _obstaclePrefab;
    [SerializeField] FlappyMovingObstacle _movingObstaclePrefab;

    [SerializeField] float _obstacleSpawnDelay;
    [SerializeField] float _obstacleSpeed;
    private float _counter;
    private int _movingCooldown = 5; 

    void Start()
    {
        _counter = _obstacleSpawnDelay;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //get time change between loop and previous loop
        _counter += Time.deltaTime;

        //spawn an obstacle if counter reaches set delay. 
        //every 3-6 obstacles, spawn a moving obstacle
        if (_counter > _obstacleSpawnDelay)
        {
            if (_movingCooldown == 0)
            {
                //Insantiate Moving Obstacle
                FlappyMovingObstacle go = Instantiate(_movingObstaclePrefab,new Vector3(10,Random.Range(-2.5f,2.5f)), Quaternion.identity);
                go._moveSpeed = _obstacleSpeed;
                _counter -= _obstacleSpawnDelay;

                //Reset Moving Cooldown to 3-6 
                _movingCooldown = Random.Range(3, 7);
            }
            else
            {
                //Instantiate Regular Obstacle
                FlappyObstacle go = Instantiate(_obstaclePrefab,new Vector3(10,Random.Range(-2.5f,2.5f)), Quaternion.identity);
                go._moveSpeed = _obstacleSpeed;
                _counter -= _obstacleSpawnDelay;

                //Decrement Moving Cooldown
                _movingCooldown -= 1;
            }  

            //Debug.Log(_movingCooldown); 
        }
    }
}
