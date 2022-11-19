using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Flamethrower : MonoBehaviour
{
    public Transform firePoint;
    public Transform pistolPos;
    public GameObject bulletPrefab;
    public GameObject pistol;
    private int ammo=999;
    private int clip=999;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(clip>0)
            {
                clip-=1;
                Shoot();
            }
            else if(clip<=0)
            {
                Instantiate(pistol, pistolPos.position, transform.rotation, transform.parent);
                Destroy(gameObject);
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
