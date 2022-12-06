using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Machinegun : MonoBehaviour
{
    public Transform firePoint;
    public Transform pistolPos;
    public GameObject bulletPrefab;
    private GameObject pistol;
    private AmmoBar ammoBar;
    private AudioSource shoot;
    public AudioSource reload;
    private float timer=0f;
    private float timerR=0f;
    private int ammo;
    private int clip;
    void Start()
    {
        shoot = GetComponent<AudioSource>();
        pistol = GameObject.FindGameObjectWithTag("Pistol");
        pistol.SetActive(false);
        ammoBar = Object.FindObjectOfType<AmmoBar>();
        ammo = 90;
        clip = 30;
        ammoBar.SetMaxAmmo(ammo,clip);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(clip>0 && timer > 0.15f)
            {
                timer=0f;
                clip-=1;
                if(clip==0 && ammo>0)
                {
                    reload.Play();
                }
                ammoBar.SetMaxAmmo(ammo,clip);
                Shoot();
            }
        }
        if(clip==0 && ammo>0)
        {
            Reload();
            shoot.Stop();
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            shoot.Stop();
        }
        if((ammo==0) && (clip==0))
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
        if(!shoot.isPlaying)
        {
            shoot.Play();
            shoot.time = 0.4f;
        }
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    void Reload()
    {
        timerR+= Time.deltaTime;
        if(ammo<30 && timerR>2f)
        {
            timerR=0;
            clip=ammo;
            ammo=0;
            ammoBar.SetMaxAmmo(ammo,clip);
        }
        if(ammo>=30 && timerR>2f)
        {
            timerR=0;
            clip=30;
            ammo-=clip;
            ammoBar.SetMaxAmmo(ammo,clip);
        }
    }
}
