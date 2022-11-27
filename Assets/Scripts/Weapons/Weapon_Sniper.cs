using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Weapon_Sniper : MonoBehaviour
{
    private Camera Camera;
    private CinemachineVirtualCamera vcam;
    public Transform firePoint;
    public Transform pistolPos;
    public GameObject bulletPrefab;
    private GameObject pistol;
    private AmmoBar ammoBar;
    private float timer=0f;
    private int ammo;
    private int clip;


    private void Start() 
    {
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
        if (Input.GetButtonDown("Fire1") && (timer > 1.5f))
        {
            if(clip>0)
            {
                timer=0f;
                clip-=1;
                ammoBar.SetMaxAmmo(ammo,clip);
                Shoot();
            }
            else if(clip==0 && ammo>0)
            {
                Reload();
            }
        }
        if((ammo==0) && (clip==0))
        {
            pistol.SetActive(true);
            vcam.m_Lens.OrthographicSize = 5f;
            Instantiate(pistol, pistolPos.position, transform.rotation, transform.parent);
            Destroy(gameObject);
            pistol.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            pistol.SetActive(true);
            vcam.m_Lens.OrthographicSize = 5f;
            Instantiate(pistol, pistolPos.position, transform.rotation, transform.parent);
            Destroy(gameObject);
            pistol.SetActive(false);
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    void Reload()
    {
        timer += Time.deltaTime;
        if(ammo<7 && timer>2f)
        {
            timer=0;
            clip=ammo;
            ammo=0;
            ammoBar.SetMaxAmmo(ammo,clip);
        }
        if(ammo>=7)
        {
            timer=0;
            clip=7;
            ammo-=clip;
            ammoBar.SetMaxAmmo(ammo,clip);
        }
    }
}
