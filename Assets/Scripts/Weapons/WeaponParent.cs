using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    
    private Camera Camera;
    private SpriteRenderer sprite;
    private SpriteRenderer spritePlayer;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spritePlayer = player.GetComponent<SpriteRenderer>();
        sprite = GetComponent<SpriteRenderer>();
        Camera = Camera.main;
    }
    private void Update() {
        Vector2 mouse = Input.mousePosition;//wczytujemy ruchy myszki

        Vector2 screenPoint = (Vector2)Camera.main.ScreenToWorldPoint(mouse) - (Vector2)transform.position;//miejsce w którym aktualnie znajduje się kursor

        screenPoint.Normalize();//

        float angle = Mathf.Atan2(screenPoint.y, screenPoint.x) * Mathf.Rad2Deg;//ustalanie kąta pomiędzy graczem a kursorem, w stopniach

        transform.rotation = Quaternion.Euler(0f,0f,angle);//ustalamy kierunek strzału(obrót broni)
        
        //ta część kodu odpowiada za obrót modelu broni i postaci w kierunku kursora
        if(transform.rotation.z >= 0.7f || transform.rotation.z <= -0.7f)
        {
            sprite.flipY = true;
            spritePlayer.flipX = true;
        }
        else
        {
            sprite.flipY = false;
            spritePlayer.flipX = false;
        }
    }
}
//ta część kodu zajęła mi za dużo czasu
//głównie przez moje ustawienia kamery w unity