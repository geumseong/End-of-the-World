﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    public ParticleSystem ps;
    public Vector2 direction;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        transform.Translate(direction * Time.deltaTime);
    }

    void OnTriggerStay2D(Collider2D collider) {
        if(collider.tag == "Enemy") {
            collider.transform.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount -= 0.2f;
            if(collider.transform.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount <= 0) {
                Destroy(collider.gameObject);
            }
            Destroy(gameObject);
        }
    }
}