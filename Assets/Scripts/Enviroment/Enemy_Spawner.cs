using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Spawner : MonoBehaviour
{
    public Text spawnText;
    private bool spawnable;
    public GameObject enemy;
    private GameObject player;
    private int child;
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
        if (spawnable && Input.GetKeyDown(KeyCode.E))
        {
            Spawn();
        }
        spawnPoint = player.transform.position + new Vector3(6,2,0);
        child = enemies.transform.childCount;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            spawnText.gameObject.SetActive(true);
            spawnable = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            spawnText.gameObject.SetActive(false);
            spawnable = false;
        }
    }
    void Spawn()
    {
        for ( int i=0;i<child;i++)
        {
            Destroy(enemies.transform.GetChild(i).gameObject);//niszczę wrogów którzy nie zostali zabici przed zespawnowaniem nowych
        }
        enemySpawn = Instantiate(enemy,spawnPoint,gameObject.transform.rotation);
        enemies.transform.position = enemySpawn.transform.position;
        enemySpawn.gameObject.transform.SetParent(enemies.transform);
    }
}
