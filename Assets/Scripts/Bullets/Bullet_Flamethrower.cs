using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Flamethrower : MonoBehaviour
{
    private float speed = 15f;
    private int damage = 1;
    private Rigidbody2D rb;
    private float timeAlive = 0.25f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, timeAlive);
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Enemy_Tank enemy = hitInfo.GetComponent<Enemy_Tank>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
