using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Text ammoMag;
    public Text ammoClip;
    public void SetMaxAmmo(int ammo, int clip)
    {
        ammoMag.text = ammo.ToString();
        ammoClip.text = clip.ToString();
    }
    public void SetAmmoMagazine(int ammo)
    {
        ammoMag.text = ammo.ToString();
    }
    public void SetAmmoClip(int clip)
    {
        ammoClip.text = clip.ToString();
    }
}
