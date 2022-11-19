using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    public float force = 10;//szybkość pocisku

    public int damage = 35;//obrażenia pocisku

    public float timeAlive = 1f;//max czas lotu pocisku

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//bierzemy rigidbody pocisku

        player = GameObject.FindGameObjectWithTag("Player");//wyszukujemy gracza po tagu danym mu w unity
//dopóki tag "Player" jest unikalny to można w ten sposób go wyszukiwać

        Vector3 direction = player.transform.position - transform.position + new Vector3(0f,1f,0f);//bez tego ostatniego vectora przeciwnik strzela mi w nogi

        rb.velocity = new Vector2(direction.x, direction.y).normalized  * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;//ustalamy kąt pomiędzy bronią a graczem

        transform.rotation = Quaternion.Euler(0f,0f,rot);//wcielamy w życie rotację pocisku

        Destroy(gameObject, timeAlive);//pocisk wystrzelony w powietrze zniknie po czasie ustalonym w timeAlive
        
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();//wyszukujemy komponent w którym mamy hp gracza
        if (player != null)
        {
            player.TakeDamage(damage);//gdy pocisk zderzy się z graczem zadaje mu obrażenia
        }
        
        if (hitInfo.name != "Tank" && hitInfo.name != "EnemyBullet(Clone)" && hitInfo.name != "Bullet_Pistol(Clone)")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
