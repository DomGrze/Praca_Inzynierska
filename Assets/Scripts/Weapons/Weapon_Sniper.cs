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
    public GameObject pistol;
    private float timer=0f;
    private int ammo=21;
    private int clip=7;


    private void Start() 
    {
        Camera = Camera.main;
        vcam = Camera.GetComponent<CinemachineVirtualCamera>();
        vcam.m_Lens.OrthographicSize = 8f;
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
                Shoot();
            }
            else if(clip==0 && ammo>0)
            {
                Reload();
            }
            else if((ammo==0) && (clip==0))
            {
                vcam.m_Lens.OrthographicSize = 5f;
                Instantiate(pistol, pistolPos.position, transform.rotation, transform.parent);
                Destroy(gameObject);
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
            {
                vcam.m_Lens.OrthographicSize = 5f;
                Instantiate(pistol, pistolPos.position, transform.rotation, transform.parent);
                Destroy(gameObject);
            }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    void Reload()
    {
        if(ammo<7)
        {
            clip=ammo;
            ammo=0;
        }
        if(ammo>7)
        {
        ammo-=clip;
        clip=7;
        }
    }
}
