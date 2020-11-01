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
    int maxAsteroids;
    int maxSmallAliens;
    int maxMedAliens;
    int maxBossAliens;
    
    /*
        Wave 1: Meteorites (10)
        Wave 2: Meteorites & Small Aliens (10 meteorites + 5 small aliens)
        Wave 3: Small Aliens & Medium Aliens (10 small aliens + 5 medium)
        Wave 4: Medium Aliens (15 mediums)
        Wave 5: Boss (1 boss)
        Infinite Stages (Maybe Implement Increasing Health system)
    */

    // Start is called before the first frame update
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
