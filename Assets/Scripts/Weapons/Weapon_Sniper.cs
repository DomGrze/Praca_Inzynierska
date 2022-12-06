using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Weapon_Sniper : MonoBehaviour
{
    private Camera Camera;
    private CinemachineVirtualCamera vcam;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private GameObject pistol;
    private AmmoBar ammoBar;
    private AudioSource shoot;
    public AudioSource reload;
    private float timer=2f;
    private float timerR=0f;
    private int ammo;
    private int clip;
    
    private void Start() 
    {
        shoot = GetComponent<AudioSource>();
        Camera = Camera.main;
        vcam = Camera.GetComponent<CinemachineVirtualCamera>();
        vcam.m_Lens.OrthographicSize = 8f;
        pistol = GameObject.FindGameObjectWithTag("Pistol");
        pistol.SetActive(false);
        ammoBar = Object.FindObjectOfType<AmmoBar>();
        ammo = 21;
        clip = 7;
        ammoBar.SetMaxAmmo(ammo,clip);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            if(clip>0 && (timer > 1.7f))
            {
                timer=0f;
                clip-=1;
                reload.Play();
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
        }
        if((ammo==0) && (clip==0) && timer>1f)
        {
            vcam.m_Lens.OrthographicSize = 5f;
            pistol.SetActive(true);
            Destroy(gameObject);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            pistol.SetActive(true);
            vcam.m_Lens.OrthographicSize = 5f;
            Destroy(gameObject);
        }
    }
    void Shoot()
    {
        shoot.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    void Reload()
    {
        timerR+= Time.deltaTime;
        if(ammo<7 && timerR>2f)
        {
            timerR=0;
            clip=ammo;
            ammo=0;
            ammoBar.SetMaxAmmo(ammo,clip);
        }
        if(ammo>=7 && timerR>2f)
        {
            timerR=0;
            clip=7;
            ammo-=clip;
            ammoBar.SetMaxAmmo(ammo,clip);
        }
    }
}
