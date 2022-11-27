using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Text pickupText;
    private bool pickable;
    private float timer=0;
    public GameObject weapon;
    private GameObject weaponSpawn;
    private GameObject player;
    private GameObject pistol;
    private WeaponParent prevWeapon;
    private WeaponParent weaponParent;
    private void Start()
    {
        pistol = GameObject.FindGameObjectWithTag("Pistol");
        pickupText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (pickable && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
        player = GameObject.FindGameObjectWithTag("Player");
        prevWeapon = player.GetComponentInChildren<WeaponParent>();
        weaponParent = prevWeapon.GetComponent<WeaponParent>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            pickupText.gameObject.SetActive(true);
            pickable = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            pickupText.gameObject.SetActive(false);
            pickable = false;
        }
    }
    void PickUp()
    {
        pistol.SetActive(true);
        Destroy(prevWeapon.gameObject);
        weaponSpawn = Instantiate(weapon.gameObject,weaponParent.transform.position,weaponParent.transform.rotation);
        weaponSpawn.gameObject.transform.SetParent(weaponParent.transform.parent);
        //Destroy(gameObject); na czas testow nie usuwam podnoszonej broni
        timer+=Time.deltaTime;
        if(timer>0.5f)
        {
            timer=0;
            pistol.SetActive(false);
        }
    }
}
