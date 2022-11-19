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
    private float timer=0f;
    private int ammo=999;
    //jako domyślna broń, pistolet będzie miał nielimitowane naboje
    //mogłaby być tu dowolna liczba, nie ma to znaczenia
    //jednak 999 na HUDzie gracza ma symbolizować niekończącą się amunicję
    private int clip=12;//Nadal będzie posiadał magazynek

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && (timer > 0.9f))
        {
            if(clip>0)
            {
                timer=0f;
                clip-=1;
                Shoot();
            }
            else if(clip<=0)
            {
                clip=12;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
