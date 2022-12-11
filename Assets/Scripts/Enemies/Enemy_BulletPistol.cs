using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BulletPistol : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    private float speed = 20f;//szybkość pocisku

    private int damage = 25;//obrażenia pocisku

    private float timeAlive = 1f;//max czas lotu pocisku

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position + new Vector3(0f,1f,0f);//bez tego ostatniego vectora przeciwnik strzela mi w nogi

        rb.velocity = new Vector3(direction.x, direction.y, 12f).normalized  * speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;//ustalam kąt pomiędzy bronią a graczem

        transform.rotation = Quaternion.Euler(0f,0f,rot);//wcielam w życie rotację pocisku

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

    void Update()
    {
        
    }
}
