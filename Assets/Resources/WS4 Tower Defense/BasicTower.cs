using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BasicTower : Tower
{
    [SerializeField] GameObject myProjectile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //every myTower.attackspeed, attack()
    }

    public override void Shoot(GameObject target)
    {

    }
}
