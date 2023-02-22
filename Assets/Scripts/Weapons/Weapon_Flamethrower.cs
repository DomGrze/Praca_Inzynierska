using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Flamethrower : MonoBehaviour
{
    public Transform firePoint;
    public Transform pistolPos;
    public GameObject bulletPrefab;
    public GameObject pistol;
    private AmmoBar ammoBar;
    private int ammo;
    private int clip;
    void Start()
    {
        pistol = GameObject.FindGameObjectWithTag("Pistol");
        pistol.SetActive(false);
        ammoBar = Object.FindObjectOfType<AmmoBar>();
        ammo = 0;
        clip = 999;
        ammoBar.SetMaxAmmo(ammo,clip);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(clip>0)
            {
                clip-=1;
                ammoBar.SetMaxAmmo(ammo,clip);
                Shoot();
            }
        }
        if(clip<=0)
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
}
