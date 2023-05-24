using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rBody;

    public float bulletSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            enemy.Die();
        }

        Destroy(this.gameObject);
    }
}
