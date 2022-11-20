using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Machinegun : MonoBehaviour
{
    public Transform firePoint;
    public Transform pistolPos;
    public GameObject bulletPrefab;
    public GameObject pistol;
    private float timer=0f;
    private int ammo=90;
    private int clip=30;

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(clip>0 && timer > 0.15f)
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
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    void Reload()
    {
        if(ammo<30)
        {
            clip=ammo;
            ammo=0;
        }
        if(ammo>30)
        {
        ammo-=clip;
        clip=30;
        }
    }
}
