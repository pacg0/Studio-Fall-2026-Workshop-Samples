using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage = 0;
    [SerializeField] private float flySpeed = 5f;
    [SerializeField] private float lifeSpan = 3f;

    void Start()
    {
        //auto destroys after lifespan! 
        Destroy(gameObject, lifeSpan);
    }

    void Update()
    {
        transform.Translate(Vector3.right * flySpeed * Time.deltaTime, Space.Self);
    }

    //so others can see how much damage they take
    public int GetDamage()
    {
        return damage;
    }

    void OnDestroy()
    {
        //play an animation (IF WE HAVE TIME TO GET TO THIS!!!! we wont teach it anyway)
    }
}
