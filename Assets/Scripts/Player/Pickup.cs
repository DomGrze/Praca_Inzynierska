using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Pickup : MonoBehaviour
{
    public Text pickupText;
    private bool pickable;
    public GameObject weapon;
    private Camera Camera;
    private CinemachineVirtualCamera vcam;
    private GameObject weaponSpawn;
    private GameObject player;
    public GameObject pistol;
    private WeaponParent prevWeapon;
    private WeaponParent weaponParent;
    private void Start()
    {
        pistol = GameObject.FindGameObjectWithTag("Pistol");
        pickupText.gameObject.SetActive(false);
        Camera = Camera.main;
        vcam = Camera.GetComponent<CinemachineVirtualCamera>();
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
            pistol.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            pickupText.gameObject.SetActive(false);
            pickable = false;
            pistol.SetActive(false);
        }
    }
    void PickUp()
    {
        // pistol.SetActive(true);
        Destroy(prevWeapon.gameObject);
        weaponSpawn = Instantiate(weapon.gameObject,weaponParent.transform.parent.position,weaponParent.transform.parent.rotation);
        weaponSpawn.gameObject.transform.SetParent(weaponParent.transform.parent);
        //Destroy(gameObject); na czas testow nie usuwam podnoszonej broni
        if(vcam.m_Lens.OrthographicSize != 5f)
        {
            vcam.m_Lens.OrthographicSize = 5f;
        }
    }
}
