using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public LayerMask collisionMask;
    public GameObject redBulletPrefab;
    public GameObject blueBulletPrefab;
    public Transform Launcher;
    public float bulletSpeed;
    public static int redAmmo = 10;
    public static int blueAmmo = 10;
    public string ammoType = "Red";
    public AudioSource gunfire;


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
        {
            ammoType = "Red";
        }
        if (Input.GetKeyDown("2"))
        {
            ammoType = "Blue";
        }
        if (Input.GetMouseButtonDown(0))
        {
            FireShot();
        }

    }

    void FireShot()
    {
        gunfire.Play();
        if (ammoType == "Red")
        {
            if (redAmmo > 0)
            {
                var bullet = (GameObject)Instantiate(redBulletPrefab, Launcher.position, Launcher.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * bulletSpeed;
                bullet.GetComponent<Rigidbody>().freezeRotation = true;
                //Destroy(bullet, 2.0f);
                redAmmo--;
            }
        }
        else
        {   if (blueAmmo > 0)
            {
                var bullet = (GameObject)Instantiate(blueBulletPrefab, Launcher.position, Launcher.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * bulletSpeed;
                //Destroy(bullet, 2.0f);
                blueAmmo--;
            }
        }

        


    }

}