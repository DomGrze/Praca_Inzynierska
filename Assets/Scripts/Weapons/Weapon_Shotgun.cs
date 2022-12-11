using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AmmoBar;
public class Weapon_Shotgun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject pistol;
    private AmmoBar ammoBar;
    private AudioSource shoot;
    public AudioSource reload;
    private float timer=2f;
    private float timerR=0f;
    private int ammo;
    private int clip;
    void Start()
    {
        shoot = GetComponent<AudioSource>();
        pistol = GameObject.FindGameObjectWithTag("Pistol");
        pistol.SetActive(false);
        ammoBar = Object.FindObjectOfType<AmmoBar>();
        ammo = 24;
        clip = 6;
        ammoBar.SetMaxAmmo(ammo,clip);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && (Time.timeScale != 0))
        {
            if(clip>0 && (timer > 2.0f))
            {
                timer=0f;
                clip-=1;
                if(clip==0 && ammo>0)
                {
                    reload.Play();
                }
                ammoBar.SetAmmoClip(clip);
                Shoot();
            }
        }
        if(clip==0 && ammo>0)
        {
            Reload();
        }
        if((ammo==0) && (clip==0) && timer>1f)
        {
            pistol.SetActive(true);
            Destroy(gameObject);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            pistol.SetActive(true);
            Destroy(gameObject);
        }
    }
    void Shoot()
    {
        shoot.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0f,0f,12f));
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0f,0f,-12f));
        //Shotgun strzela trzema pociskami z rozproszeniem
    }
    void Reload()
    {
        timerR+=Time.deltaTime;
        if(ammo<6 && timerR>2f)
        {
            timerR=0;
            clip=ammo;
            ammo=0;
            ammoBar.SetMaxAmmo(ammo,clip);
        }
        if(ammo>=6 && timerR>2f)
        {
            timerR=0;
            clip=6;
            ammo = ammo-clip;
            ammoBar.SetMaxAmmo(ammo,clip);
        }
    }
}
