using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meteorite : MonoBehaviour
{
    //public GameObject player;
    public float speed;
    public Vector3 direction;
    public int healthPoint = 100;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = transform.position - GameObject.Find("earth").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerStay2D(Collider2D collision) {
        if(collision.tag == "Player") {
            GameObject healthPoint = GameObject.Find("EarthHPBarFull");
            healthPoint.GetComponent<Image>().fillAmount -= 0.1f;
            Debug.Log("collided");
            if(healthPoint.GetComponent<Image>().fillAmount <= 0) {
                Debug.Log("Game Over");
                Time.timeScale = 0f;
            }
            Destroy(gameObject);
        }
    }
}
