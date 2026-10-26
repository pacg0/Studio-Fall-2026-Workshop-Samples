using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FlappyMovement : MonoBehaviour
{

    //declaring variables
    [SerializeField] private float flapVelocity = 55f;
    [SerializeField] private float maxFallSpeed = -10f;
    [SerializeField] private float maxRiseSpeed = 10f;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    //Unity Event called by Input Manager
    public void OnFlap(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        Vector2 velocity = _rb.linearVelocity;
        velocity.y = flapVelocity;

        velocity.y = Mathf.Clamp(velocity.y, maxFallSpeed, maxRiseSpeed);

        _rb.linearVelocity = velocity;
    }

    //Collision with obstacles
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("WS3 - Flappy Bird");
        }
    }

}
