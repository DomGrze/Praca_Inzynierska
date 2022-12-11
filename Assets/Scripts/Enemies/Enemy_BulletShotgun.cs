using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BulletShotgun : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    private float speed = 10f;//szybkość pocisku

    private int damage = 25;//obrażenia pocisku

    private float timeAlive = 0.5f;//max czas lotu pocisku

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        if (player.transform.position.x <= transform.position.x)
        {
            rb.velocity = -transform.right * speed;
        }
        else
        {
            rb.velocity = transform.right * speed;
        }
        Destroy(gameObject, timeAlive);//pocisk wystrzelony w powietrze zniknie po czasie ustalonym w timeAlive
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();//wyszukuje komponent w którym mam hp gracza
        if (player != null)
        {
            player.TakeDamage(damage);//gdy pocisk zderzy się z graczem zadaje mu obrażenia
        }
        
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}