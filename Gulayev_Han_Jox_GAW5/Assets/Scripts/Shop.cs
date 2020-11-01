using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameStateManager gameStateManager;
    string selected;
    public GameObject primaryButton;
    public GameObject rocketButton;
    public GameObject laserButton;
    public GameObject iceButton;
    public GameObject futureButton;
    public GameObject healthButton;
    public List<Sprite> primarySprite;
    public List<Sprite> rocketSprite;
    public List<Sprite> laserSprite;
    public List<Sprite> iceSprite;
    public List<Sprite> futureSprite;
    public List<Sprite> healthSprite;
    public Text description;


    public void Stater() {
        gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
    }

    public void Update()
    {
       
    }

    public void PressOnPrimary() {
        selected = "primary";
        primaryButton.GetComponent<Image>().sprite = primarySprite[1];
        rocketButton.GetComponent<Image>().sprite = rocketSprite[0];
        laserButton.GetComponent<Image>().sprite = laserSprite[0];
        iceButton.GetComponent<Image>().sprite = iceSprite[0];
        futureButton.GetComponent<Image>().sprite = futureSprite[0];
        healthButton.GetComponent<Image>().sprite = healthSprite[0];
        description.text = "Name: \n-Upgrade Primary\nDamage: +damage (0/3)";
    }

    public void PressOnRocket() {
        selected = "rocket";
        primaryButton.GetComponent<Image>().sprite = primarySprite[0];
        rocketButton.GetComponent<Image>().sprite = rocketSprite[1];
        laserButton.GetComponent<Image>().sprite = laserSprite[0];
        iceButton.GetComponent<Image>().sprite = iceSprite[0];
        futureButton.GetComponent<Image>().sprite = futureSprite[0];
        healthButton.GetComponent<Image>().sprite = healthSprite[0];
        description.text = "Name: \n-Rocket Launcher\nRange: 7\nFire Rate: \nDamage: ";
    }

    public void PressOnLaser() {
        selected = "laser";
        primaryButton.GetComponent<Image>().sprite = primarySprite[0];
        rocketButton.GetComponent<Image>().sprite = rocketSprite[0];
        laserButton.GetComponent<Image>().sprite = laserSprite[1];
        iceButton.GetComponent<Image>().sprite = iceSprite[0];
        futureButton.GetComponent<Image>().sprite = futureSprite[0];
        healthButton.GetComponent<Image>().sprite = healthSprite[0];
        description.text = "Name: \n-Laser Shooter\nRange: 10\nFire Rate: \nDamage: ";
    }

    public void PressOnIce() {
        selected = "ice";
        primaryButton.GetComponent<Image>().sprite = primarySprite[0];
        rocketButton.GetComponent<Image>().sprite = rocketSprite[0];
        laserButton.GetComponent<Image>().sprite = laserSprite[0];
        iceButton.GetComponent<Image>().sprite = iceSprite[1];
        futureButton.GetComponent<Image>().sprite = futureSprite[0];
        healthButton.GetComponent<Image>().sprite = healthSprite[0];
        description.text = "Name: \n-Ice Thrower\nRange: 15\nFire Rate: \nDamage: ";
    }

    public void PressOnFuture() {
        selected = "future";
        primaryButton.GetComponent<Image>().sprite = primarySprite[0];
        rocketButton.GetComponent<Image>().sprite = rocketSprite[0];
        laserButton.GetComponent<Image>().sprite = laserSprite[0];
        iceButton.GetComponent<Image>().sprite = iceSprite[0];
        futureButton.GetComponent<Image>().sprite = futureSprite[1];
        healthButton.GetComponent<Image>().sprite = healthSprite[0];
        description.text = "Name: \n-Future Tech\nRange: 15\nFire Rate: \nDamage: ";
    }

    public void PressOnHealth() {
        selected = "health";
        primaryButton.GetComponent<Image>().sprite = primarySprite[0];
        rocketButton.GetComponent<Image>().sprite = rocketSprite[0];
        laserButton.GetComponent<Image>().sprite = laserSprite[0];
        iceButton.GetComponent<Image>().sprite = iceSprite[0];
        futureButton.GetComponent<Image>().sprite = futureSprite[0];
        healthButton.GetComponent<Image>().sprite = healthSprite[1];
        description.text = "Name: \n-Health Kit\nHeal Amount:\n-25%";
    }

    public void Buy() {
        switch(selected) {
            case "primary":
                if(gameStateManager.money >= 100)
                gameStateManager.DecreaseMoney(100);
                break;
            case "rocket":
                if(gameStateManager.money >= 100)
                gameStateManager.DecreaseMoney(100);
                break;
            case "laser":
                if(gameStateManager.money >= 300)
                gameStateManager.DecreaseMoney(300);
                break;
            case "ice":
                if(gameStateManager.money >= 300)
                gameStateManager.DecreaseMoney(300);
                break;
            case "future":
                if(gameStateManager.money >= 500)
                gameStateManager.DecreaseMoney(500);
                break;
            case "health":
                if(gameStateManager.money >= 200)
                gameStateManager.DecreaseMoney(200);
                break;
        }
    }

    public void Sell() {

    }
}
