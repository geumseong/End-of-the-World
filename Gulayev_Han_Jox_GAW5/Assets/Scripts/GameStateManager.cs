using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    EnemySpawner enemySpawner;
    public GameObject waveCountObj;
    int waveCount;
    public GameObject buyTimeObj;
    
    void Start()
    {
        enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
        waveCount = 0;
        waveCountObj.GetComponent<Text>().text = "Waves: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNextWave() {
        waveCount++;
        waveCountObj.GetComponent<Text>().text = "Waves: " + waveCount;
        enemySpawner.StartSpawnEnemy(waveCount);
    }
}
