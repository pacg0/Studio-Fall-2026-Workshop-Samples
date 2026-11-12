using UnityEngine;

public class Ice_Projectile : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
         
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.ChangeSpeed(0,2);
                //Debug.Log("Ouch");
            }
            
            Destroy(gameObject);
        }
    }
}
