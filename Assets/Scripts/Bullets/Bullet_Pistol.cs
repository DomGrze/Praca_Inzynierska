using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Pistol : MonoBehaviour
{
    private float speed = 10f;
    private int damage = 25;
    private Rigidbody2D rb;
    private float timeAlive = 1f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, timeAlive);
    }
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy_Tank enemy = hitInfo.GetComponent<Enemy_Tank>();
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if (hitInfo.CompareTag("Enemy") || hitInfo.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
