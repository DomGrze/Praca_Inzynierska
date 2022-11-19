using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Shotgun : MonoBehaviour
{
    private float speed = 10f;
    private int damage = 25;
    private Rigidbody2D rb;
    private float timeAlive = 0.5f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, timeAlive);
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (hitInfo.name != "Player" && hitInfo.name != "EnemyBullet(Clone)" && hitInfo.name != "Bullet_Shotgun(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
