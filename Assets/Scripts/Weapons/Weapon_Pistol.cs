using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//pistolet ma być bronią domyślną, dlatego jego kod różni się od reszty
//nie posiada funkcji Reload(), ani nie jest niszczony przez
//Destroy(gameObject)
//pistolet ma być zawsze dostępny w razie zniszczenia innych broni

public class Weapon_Pistol : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private AudioSource shoot;
    public AudioSource reload;
    private float timer=1f;
    private float timerR=0f;
    private int ammo=999;
    //jako domyślna broń, pistolet będzie miał nielimitowane naboje
    //mogłaby być tu dowolna liczba, nie ma to znaczenia
    //jednak 999 na HUDzie gracza ma symbolizować niekończącą się amunicję
    private int clip=12;//Nadal będzie posiadał magazynek
    private AmmoBar ammoBar;

    void Start() 
    {
        shoot = GetComponent<AudioSource>();
        ammoBar = Object.FindObjectOfType<AmmoBar>();
    }
    void Update()
    {
        ammoBar.SetMaxAmmo(ammo, clip);
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && (timer > 0.9f) && (Time.timeScale != 0))
        {
            if(clip>0)
            {
                timer=0f;
                clip-=1;
                if(clip==0)
                {
                    reload.Play();
                }
                ammoBar.SetMaxAmmo(ammo,clip);
                Shoot();
            }
        }
        if(clip<=0)
        {
            timerR+=Time.deltaTime;
            if(timerR > 1f)
            {
                timerR=0f;
                clip=12;
                ammoBar.SetMaxAmmo(ammo,clip);
            }
        }
    }
    void Shoot()
    {
        shoot.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
