using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform launchPosition;

    private AudioSource audioSource;

    public bool isUpgraded;
    public float upgradeTime = 10.0f;
    private float currentTime;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsInvoking("fireBullet"))
            {
                InvokeRepeating("fireBullet", 0f, 0.1f);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("fireBullet");
        }
        currentTime += Time.deltaTime;
        if (currentTime > upgradeTime && isUpgraded == true)
        {
            isUpgraded = false;
        }
		
	}

    void fireBullet()
    {
        Rigidbody bullet = CreateBullet();
        bullet.velocity = transform.parent.forward * 100;
        if (isUpgraded)
        {
            Rigidbody bullet2 = CreateBullet();
            bullet2.velocity = (transform.right + transform.forward / 0.5f) * 100;
            Rigidbody bullet3 = CreateBullet();
            bullet3.velocity = (transform.right * -1 + transform.forward / 0.5f) * 100;
            audioSource.PlayOneShot(SoundManager.Instance.upgradeGunFire);
        }
        else
        {
            audioSource.PlayOneShot(SoundManager.Instance.gunFire);
        }

        
    }

    public void UpgradedGun()
    {
        isUpgraded = true;
        currentTime = 0;
    }

    private Rigidbody CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = launchPosition.position;
        return bullet.GetComponent<Rigidbody>();
    }

}
