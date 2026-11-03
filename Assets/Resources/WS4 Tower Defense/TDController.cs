using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using TMPro;
using UnityEngine.UI;

public class TDController : MonoBehaviour
{
    [SerializeField] int money = 5;
    [SerializeField] int lives = 25;

    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI waveCounterText;
    [SerializeField] TextMeshProUGUI lifeCounterText;
    [SerializeField] TextMeshProUGUI moneyCounterText;
    [SerializeField] Button waveButton;

    public static TDController instance;
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else Destroy(this);

        moneyCounterText.text = "Money: " + money;
        lifeCounterText.text = "Lives: " + lives;
        waveCounterText.text = "Wave: " + waveCounter;
    }
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

    public void AddMoney(int amt)
    {
        money += amt;
        moneyCounterText.text = "Money: " + money;
    }

    public bool TrySubtractMoney(int amt)
    {
        if (money - amt < 0) return false;
        money -= amt;
        moneyCounterText.text = "Money: " + money;
        return true;
    }
    public void SubtractLives(int amt)
    {
        lives -= amt;
        lifeCounterText.text = "Lives: " + lives;
        if (lives <= 0)
        {
            Application.Quit();
        }
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
        waveCounterText.text = "Wave: " + waveCounter;
    }

    private IEnumerator SpawnWaveRoutine(int waveIndex)
    {
        isSpawningWave = true;
        waveButton.interactable = false;
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
        waveButton.interactable = true;
    }

}
