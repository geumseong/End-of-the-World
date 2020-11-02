﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    EnemySpawner enemySpawner;
    public GameObject waveCountObj;
    int waveCount;
    public GameObject nextWaveButton;
    public bool waveStatus;
    public bool countDownStatus;
    public GameObject countDownObj;
    private IEnumerator coroutine;
    public GameObject shopUI;
    public GameObject moneyOwnedTxt;
    public int money = 0;
    public GameObject GameOverUI;

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        GameObject.Find("WaveCountTXT").GetComponent<Text>().text = "Waves Survived: \n" + (waveCount - 1);
        Time.timeScale = 0f;
    }
    
    void Start()
    {
        countDownObj.SetActive(false);
        enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
        waveCount = 0;
        waveCountObj.GetComponent<Text>().text = "Waves: 0";
        moneyOwnedTxt.GetComponent<Text>().text = "Owned Money: " + money;
        GameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseMoney(int income) {
        money += income;
        moneyOwnedTxt.GetComponent<Text>().text = "Owned Money: " + money;
    }

    public void DecreaseMoney(int payment) {
        money -= payment;
        moneyOwnedTxt.GetComponent<Text>().text = "Owned Money: " + money;
    }

    public void StartNextWave() {
        waveStatus = true;
        countDownStatus = false;
        if(coroutine != null) {
            StopCoroutine(coroutine);
        }
        waveCount++;
        waveCountObj.GetComponent<Text>().text = "Waves: " + waveCount;
        enemySpawner.StartSpawnEnemy(waveCount);
        nextWaveButton.SetActive(false);
        countDownObj.SetActive(false);
        shopUI.SetActive(false);
    }

    public void StartCountDown() {
        coroutine = CountDown();
        StartCoroutine(coroutine);
    }
    
    IEnumerator CountDown() {
        shopUI.SetActive(true);
        nextWaveButton.SetActive(true);
        countDownObj.SetActive(true);
        countDownStatus = true;
        int seconds = 60;
        while(seconds > 0) {
            Debug.Log(seconds);
            countDownObj.GetComponent<Text>().text = "NEXT WAVE IN: " + seconds;
            yield return new WaitForSeconds(1f);
            seconds--;
        }
        StartNextWave();
        countDownObj.SetActive(false);
        yield return null;
    }
}
