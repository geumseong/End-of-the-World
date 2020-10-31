using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    Vector2 direction;
    public float force;
    public GameObject projectile;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rotationPivot = transform.position; //position of your turret
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //position of moouse
        direction = mousePosition - rotationPivot; //Finds Vector2 direction by (mousePos - turretPos)
        transform.up = direction; //And transform.up - direction somehow does the rest.
        if(Input.GetMouseButtonUp(0)) {
            Shoot();
        }
    }

    public void Shoot(){
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.position = transform.position;
        newProjectile.GetComponent<Projectile>().damage = damage;
        newProjectile.GetComponent<Rigidbody2D>().AddForce(direction * force);
    }
}
