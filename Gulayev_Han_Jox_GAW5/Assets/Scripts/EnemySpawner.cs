using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject meteorite;
    public GameObject smallAliens;
    public GameObject mediumAliens;
    public GameObject bossAliens;
    public List<GameObject> spawnPoints;

    // Start is called before the first frame update
    public void StartSpawnEnemy(int waveCount)
    {
        StartCoroutine(SpawnEnemy(waveCount));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy(int waveCount) {
        if(waveCount > 5) {

        }
        else if(waveCount == 1) {
            int meteoriteCount = 0;
            int maxMeteoriteCount = 10;
            while(meteoriteCount < maxMeteoriteCount) {
                yield return new WaitForSeconds(2);
                int spawnPoint = Random.Range(0, 14);
                GameObject selectedSpawn = spawnPoints[spawnPoint];
                Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                GameObject newEnemy = Instantiate(meteorite, spawnPosition, transform.rotation);
                newEnemy.GetComponent<Meteorite>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                meteoriteCount++;
            }
            yield return null;
        }
        else if(waveCount == 2) {
            int meteoriteCount = 0;
            int smallAlienCount = 0;
            int maxMeteoriteCount = 10;
            int maxSmallAlienCount = 5;
            int totalSpawn = 0;
            while(totalSpawn < (maxMeteoriteCount + maxSmallAlienCount)) {
                int random = Random.Range(0, 3);
                yield return new WaitForSeconds(2);
                if(random < 2) {
                    if(meteoriteCount < maxMeteoriteCount) {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(meteorite, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<Meteorite>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        meteoriteCount++;
                    }
                    else {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(smallAliens, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<SmallAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        smallAlienCount++;
                    }
                }
                else if(random == 2) {
                    if(smallAlienCount < maxSmallAlienCount) {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(smallAliens, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<SmallAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        smallAlienCount++;
                    }
                    else {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(meteorite, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<Meteorite>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        meteoriteCount++;
                    }
                }
            }
            yield return null;
        }
        else if(waveCount == 3) {
            int mediumAlienCount = 0;
            int smallAlienCount = 0;
            int maxMediumAlienCount = 5;
            int maxSmallAlienCount = 10;
            int totalSpawn = 0;
            while(totalSpawn < (maxMediumAlienCount + maxSmallAlienCount)) {
                int random = Random.Range(0, 3);
                yield return new WaitForSeconds(2);
                if(random == 2) {
                    if(mediumAlienCount < maxMediumAlienCount) {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(mediumAliens, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<SmallAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        mediumAlienCount++;
                    }
                    else {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(smallAliens, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<SmallAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        smallAlienCount++;
                    }
                }
                else if(random < 2) {
                    if(smallAlienCount < maxSmallAlienCount) {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(smallAliens, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<SmallAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        smallAlienCount++;
                    }
                    else {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(mediumAliens, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<SmallAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        mediumAlienCount++;
                    }
                }
            }
            yield return null;
        }
        else if(waveCount == 4) {
            int mediumAlienCount = 0;
            int maxMediumAlienCount = 15;
            while(mediumAlienCount < maxMediumAlienCount) {
                yield return new WaitForSeconds(2);
                int spawnPoint = Random.Range(0, 14);
                GameObject selectedSpawn = spawnPoints[spawnPoint];
                Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                GameObject newEnemy = Instantiate(mediumAliens, spawnPosition, transform.rotation);
                newEnemy.GetComponent<SmallAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                mediumAlienCount++;
            }
            yield return null;
        }
        else if(waveCount == 5) {
            yield return new WaitForSeconds(2);
            int spawnPoint = Random.Range(0, 14);
            GameObject selectedSpawn = spawnPoints[spawnPoint];
            Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
            GameObject newEnemy = Instantiate(bossAliens, spawnPosition, transform.rotation);
            newEnemy.GetComponent<SmallAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
        }
        yield return null;
    }
}
