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
    private float timer=0f;
    private int ammo;
    private int clip;
    void Start()
    {
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
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    void Reload()
    {
        timer += Time.deltaTime;
        if(ammo<30 && timer>2f)
        {
            timer=0;
            clip=ammo;
            ammo=0;
            ammoBar.SetMaxAmmo(ammo,clip);
        }
        if(ammo>=30 && timer>2f)
        {
            timer=0;
            clip=30;
            ammo-=clip;
            ammoBar.SetMaxAmmo(ammo,clip);
        }
    }
}
