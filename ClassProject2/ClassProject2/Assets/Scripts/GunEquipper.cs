using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour
{

    // Use this for initialization

    public static string activeWeaponType;
    public GameObject pistol;
    public GameObject assultRifle;
    public GameObject shotgun;


    public GameObject activeGun;

    void Start()
    {
        activeWeaponType = Constants.Pistol;
        activeGun = pistol;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            loadWeapon(pistol);
            activeWeaponType = Constants.Pistol;
        }
        if (Input.GetKeyDown("2"))
        {
            loadWeapon(assultRifle);
            activeWeaponType = Constants.AssaultRifle;
        }
        if (Input.GetKeyDown("3"))
        {
            loadWeapon(shotgun);
            activeWeaponType = Constants.Shotgun;
        }


    }

    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }

    private void loadWeapon(GameObject weapon)
    {
        pistol.SetActive(false);
        assultRifle.SetActive(false);
        shotgun.SetActive(false);
        weapon.SetActive(true);
        activeGun = weapon;
    }
}
