using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    public ParticleSystem ps;
    public float damage;
    public float speed;
    Transform target;
    GameObject gameStateManagerObj;

    public void Seek (Transform _target) {
        target = _target;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameStateManagerObj = GameObject.Find("GameStateManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) {
            Destroy(gameObject);
            return;
        }
        
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        float angle = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if(dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget() {
        target.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount -= damage;
        if(target.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount <= 0) {
            if(target.gameObject.transform.parent.gameObject.tag == "Meteorite"){
                gameStateManagerObj.GetComponent<GameStateManager>().IncreaseMoney(20);
            }
            else if(target.gameObject.transform.parent.gameObject.tag == "SmallAlien") {
                gameStateManagerObj.GetComponent<GameStateManager>().IncreaseMoney(50);
            }
            else if(target.gameObject.transform.parent.gameObject.tag == "MediumAlien") {
                gameStateManagerObj.GetComponent<GameStateManager>().IncreaseMoney(100);
            }
            else if(target.gameObject.transform.parent.gameObject.tag == "BossAlien") {
                gameStateManagerObj.GetComponent<GameStateManager>().IncreaseMoney(300);
            }
            Destroy(target.gameObject.transform.parent.gameObject);
            if(gameStateManagerObj.GetComponent<GameStateManager>().waveStatus == false
                && gameStateManagerObj.GetComponent<GameStateManager>().countDownStatus == false) {
                gameStateManagerObj.GetComponent<GameStateManager>().StartCountDown();
            }
        }
        Destroy(gameObject);
    }
    void OnTriggerStay2D(Collider2D collider) {
        if(collider.tag == "ProjectileRemover") {
            Destroy(gameObject);
        }
    }
}
