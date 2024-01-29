using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public DemoEnemy enemyPrefab;
    
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public Checkpoint[] checkpoints;
    public TextMeshProUGUI countdownText;

    private float _countdown;

    private int _waveIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        _countdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        _countdown -= Time.deltaTime;
        countdownText.text = Mathf.Round(_countdown).ToString(CultureInfo.CurrentCulture)+'s';
        if (_countdown <= 0)
        {
            _countdown = timeBetweenWaves;
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        // 每次开始进行spawn就把index+1
        _waveIndex++;
        StartCoroutine(StartSpawn());
    }

    void SpawnEnemy()
    {
        DemoEnemy e = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        e.checkpoints = checkpoints;
    }

    IEnumerator StartSpawn()
    {
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.3f);
        }
    }
}