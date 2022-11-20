using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pistol : MonoBehaviour
{
    private GameObject player;
    public GameObject bullet;
    public Transform firePoint;
    private float timer=0f;
    void Start()
    {
        
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");//szukamy gracza po tagu "Player"

        float distance = UnityEngine.Vector2.Distance(transform.position, player.transform.position);//sprawdzamy odległość przeciwnika od gracza

        if(distance<10)//jeśli przeciwnik znajduje się w takiej odległości od gracza, może strzelać
        {
            timer += Time.deltaTime;//liczenie czasu pomiędzy kolejnymi strzałami

            if(timer > 1)//jeśli minął ten czas, można strzelać
            {
                timer = 0;//resetujemy czas

                Shoot();//strzelamy
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
