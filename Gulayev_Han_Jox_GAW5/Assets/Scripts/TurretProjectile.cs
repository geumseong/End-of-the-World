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

    public void Seek (Transform _target) {
        target = _target;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            Destroy(target.gameObject.transform.parent.gameObject);
        }
        Destroy(gameObject);
    }

    /*
    void OnTriggerStay2D(Collider2D collider) {
        if(collider.tag == "Enemy") {
            collider.transform.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount -= damage;
            if(collider.transform.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount <= 0) {
                Destroy(collider.gameObject);
            }
            Destroy(gameObject);
        }
    }
    */
}
