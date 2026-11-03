using UnityEngine;

public class FlappyMovingObstacle : MonoBehaviour
{
    public float _moveSpeed;
    public float _verticalSpeed;
    private bool _goingDown;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocityX = _moveSpeed;
    }

    private void Update()
    {
        if (transform.position.x <= -10)
            Destroy(gameObject);

        //Make it Move Up/Down
        if (transform.position.y >= 2f)
        {
           _goingDown = true;
        }
        else if (transform.position.y <= -2f)
        {
            _goingDown = false;
        }

        if (_goingDown == true)
        {
            _rb.linearVelocityY = - _verticalSpeed;
        }
        else
        {
            _rb.linearVelocityY =  _verticalSpeed;
        }

        //Debug.Log(transform.position.y);
        //Debug.Log(_goingDown);
    }
}
