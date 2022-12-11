using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawnpoint : MonoBehaviour
{
    private bool spawnable;
    public GameObject enemy;
    private GameObject player;
    public int Amount=1;
    private GameObject enemies;
    private GameObject enemySpawn;
    private Vector2 spawnPoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectWithTag("Enemies");
    }
    private void Update()
    {
        spawnPoint = player.transform.position + new Vector3(20,5,0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            for(int i=0;i<Amount;i++)
            {
                Spawn();
            }
        }
    }
    void Spawn()
    {
        enemySpawn = Instantiate(enemy,spawnPoint,gameObject.transform.rotation);
        enemies.transform.position = enemySpawn.transform.position;
        enemySpawn.gameObject.transform.SetParent(enemies.transform);
        Destroy(gameObject);
    }
}
