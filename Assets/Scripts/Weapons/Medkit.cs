using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    private int heal=50;
    public AudioSource healing;
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.HealDamage(heal);
            healing.Play();
            //Destroy(gameObject);
        }
    }
}
