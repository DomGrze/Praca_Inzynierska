using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Shotgun : MonoBehaviour
{
    public Transform firePoint;
    public Transform pistolPos;
    public GameObject bulletPrefab;
    public GameObject pistol;
    private float timer=0f;
    private int ammo=18;
    private int clip=6;

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && (timer > 2.0f))
        {
            if(clip>0)
            {
                timer=0f;
                clip-=1;
                Shoot();
            }
            else if(clip==0 && ammo>0)
            {
                Reload();
            }
            else if((ammo==0) && (clip==0))
            {
                Instantiate(pistol, pistolPos.position, transform.rotation, transform.parent);

                Destroy(gameObject);
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(pistol, pistolPos.position, transform.rotation, transform.parent);
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0f,0f,12f));
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0f,0f,-12f));
        //Shotgun strzela trzema pociskami z rozproszeniem
    }

    void Reload()
    {
        if(ammo<6)
        {
            clip=ammo;
            ammo=0;
        }
        if(ammo>6)
        {
        ammo-=clip;
        clip=6;
        }
    }
}
