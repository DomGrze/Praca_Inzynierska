using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Medkit : MonoBehaviour
{
    private int heal=50;
    private bool pickedUp=false;
    private float timer=0f;
    public AudioSource healing;
    void Update()
    {
        if(pickedUp)
        {
            timer += Time.deltaTime;
        }
        if(timer > 0.5f && SceneManager.GetActiveScene().buildIndex != 1)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            pickedUp = true;
            player.HealDamage(heal);
            healing.Play();
        }
    }
}
