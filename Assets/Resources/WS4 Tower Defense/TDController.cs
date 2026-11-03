using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class TDController : MonoBehaviour
{
    [SerializeField] int money = 5;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI waveText;

    //spawninfo binds a delay to a specific unit, unit will spawn then wait to spawn next one
    [System.Serializable]
    public class SpawnInfo
    {
        public GameObject enemyPrefab;
        public float delayAfterSpawn = 1f;
    }

    //a wave is a List of SpawnInfo
    [System.Serializable]
    public class WaveData
    {
        public string waveName = "Wave";
        public List<SpawnInfo> enemiesToSpawn = new List<SpawnInfo>();
    }

    //everything, the total list of waves (wavedatas)
    [SerializeField] private List<WaveData> waves = new List<WaveData>();

    private int currentWaveIndex = 0;
    private int waveCounter = 0;
    private bool isSpawningWave = false;


    void Start()
    {
    }

    void Update()
    {
        if (moneyText != null)
        {
            moneyText.text = "Money: " + money;
            //Debug.Log("good");
        }

        if (waveText != null)
        {
            waveText.text = "Wave: " + waveCounter;
        }
    }

    public bool TrySubtractMoney(int amt)
    {
        if (money - amt < 0) return false;
        money -= amt;
        return true;
    }

    public void AddMoney(int amt)
    {
        money += amt;
    }

    public void BeginWave()
    {
        if (isSpawningWave)
        {
            //Debug.Log("wave currently spawning");
            return;
        }

        if (currentWaveIndex >= waves.Count)
        {
            Debug.Log("No more waves. Game completed.");
            return;
        }

        StartCoroutine(SpawnWaveRoutine(currentWaveIndex));
        currentWaveIndex++;
        waveCounter++;
    }

    private IEnumerator SpawnWaveRoutine(int waveIndex)
    {
        isSpawningWave = true;
        WaveData currentWave = waves[waveIndex];
        Debug.Log($"Begin {currentWave.waveName}.");

        foreach (SpawnInfo spawnInfo in currentWave.enemiesToSpawn)
        {
            if (spawnInfo.enemyPrefab != null)
            {
                //instantiate prefab! 
                Vector3 spawnPos = Vector3.zero;
                Instantiate(spawnInfo.enemyPrefab, spawnPos, Quaternion.identity);
            }

            //wait delay
            yield return new WaitForSeconds(spawnInfo.delayAfterSpawn);
        }

        isSpawningWave = false;
        //Debug.Log($"{currentWave.waveName} completed.");
    }
}
