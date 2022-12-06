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
    private GameObject pistol;
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
        weaponParent = player.GetComponentInChildren<WeaponParent>();
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
            // pistol.SetActive(false);
        }
    }
    void PickUp()
    {
        pistol.SetActive(true);
        weaponSpawn = Instantiate(weapon.gameObject,weaponParent.transform.parent.position,weaponParent.transform.parent.rotation);
        weaponSpawn.gameObject.transform.SetParent(weaponParent.transform.parent);
        //Destroy(gameObject); //na czas testow nie usuwam podnoszonej broni
        if(vcam.m_Lens.OrthographicSize != 5f)
        {
            vcam.m_Lens.OrthographicSize = 5f;
        }
        if (weaponParent.gameObject.transform.childCount >= 2)
        {
            Destroy(weaponParent.gameObject);
        }
    }
}
