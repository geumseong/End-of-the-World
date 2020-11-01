using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    public ParticleSystem ps;
    public Vector2 direction;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnTriggerStay2D(Collider2D collider) {
        if(collider.tag == "Enemy") {
            collider.transform.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount -= damage;
            if(collider.transform.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount <= 0) {
                Destroy(collider.gameObject.transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
        else if(collider.tag == "ProjectileRemover") {
            Destroy(gameObject);
        }
    }
}
