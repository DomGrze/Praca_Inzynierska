using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Flamethrower : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject pistol;
    private AmmoBar ammoBar;
    private AudioSource shoot;
    private int ammo;
    private int clip;
    void Start()
    {
        shoot = GetComponent<AudioSource>();
        pistol = GameObject.FindGameObjectWithTag("Pistol");
        pistol.SetActive(false);
        ammoBar = Object.FindObjectOfType<AmmoBar>();
        ammo = 999;
        clip = 999;
        ammoBar.SetMaxAmmo(ammo,clip);
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && (Time.timeScale != 0))
        {
            if(clip>0)
            {
                //clip-=1;
                ammoBar.SetMaxAmmo(ammo,clip);
                Shoot();
            }
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            shoot.Stop();
        }
        if(clip<=0)
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
        }
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
