using UnityEngine;

public class FlappyObstacle : MonoBehaviour
{

    public float _moveSpeed;
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
    }
}
