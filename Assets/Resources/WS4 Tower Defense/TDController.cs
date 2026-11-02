using UnityEngine;

public class TDController : MonoBehaviour
{
    int waveCounter = 0;
    int money = 0;


    void Start()
    {
    }

    void Update()
    {
    }
    
    public int getMoney()
    {
        return money;
    }


    
    public void BeginWave(){
        Debug.Log("wow");
    }
}
