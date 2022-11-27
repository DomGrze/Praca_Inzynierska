using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AmmoBar;
public class Weapon_Shotgun : MonoBehaviour
{
    public Transform firePoint;
    public Transform pistolPos;
    public GameObject bulletPrefab;
    private GameObject pistol;
    private AmmoBar ammoBar;
    private float timer=0f;
    private int ammo;
    private int clip;
    void Start()
    {
        pistol = GameObject.FindGameObjectWithTag("Pistol");
        pistol.SetActive(false);
        ammoBar = Object.FindObjectOfType<AmmoBar>();
        ammo = 1;
        clip = 1;
        ammoBar.SetMaxAmmo(ammo,clip);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && (timer > 2.0f))
        {
            if(clip>0)
            {
                timer=0f;
                clip-=1;
                ammoBar.SetAmmoClip(clip);
                Shoot();
            }
        }
        if(clip==0 && ammo>0)
        {
            Reload();
        }
        if((ammo==0) && (clip==0))
        {
            pistol.SetActive(true);
            Instantiate(pistol, pistolPos.position, transform.rotation, transform.parent);
            Destroy(gameObject);
            pistol.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            pistol.SetActive(true);
            Instantiate(pistol, pistolPos.position, transform.rotation, transform.parent);
            Destroy(gameObject);
            pistol.SetActive(false);
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
        timer+=Time.deltaTime;
        if(ammo<6 && timer>2f)
        {
            timer=0;
            clip=ammo;
            ammo=0;
            ammoBar.SetMaxAmmo(ammo,clip);
        }
        if(ammo>=6 && timer>2f)
        {
            timer=0;
            clip=6;
            ammo = ammo-clip;
            ammoBar.SetMaxAmmo(ammo,clip);
        }
    }
}
