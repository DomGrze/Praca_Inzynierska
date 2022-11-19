using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Weapon_Sniper : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public Transform firePoint;
    public Transform pistolPos;
    public GameObject bulletPrefab;
    public GameObject pistol;
    private float timer=0f;
    private int ammo=0;
    private int clip=4;

    void Update()
    {
        vcam.m_Lens.OrthographicSize = 8f;
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(clip>0 && timer > 2f)
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
