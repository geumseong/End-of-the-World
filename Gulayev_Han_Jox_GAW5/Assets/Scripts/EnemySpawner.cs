using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy() {
        while(true) {
            int spawnPoint = Random.Range(0, 14);
            GameObject selectedSpawn = spawnPoints[spawnPoint];
            Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
            GameObject newEnemy = Instantiate(enemy, spawnPosition, transform.rotation);
            newEnemy.GetComponent<Meteorite>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
            yield return new WaitForSeconds(2);
        }
        yield return null;
    }
}
