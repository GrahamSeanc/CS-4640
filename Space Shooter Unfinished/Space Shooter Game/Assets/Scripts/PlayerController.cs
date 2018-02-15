using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Boundary boundary;
    public float tilt;
    public bool isPoweredUp;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            if (isPoweredUp)
            {   
                fireRate = 0.1f;
                
            }
            else
            {
                fireRate = 0.25f;
            }
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();         
        }
    }




    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Upgrade"))
        {
            isPoweredUp = true;
            Invoke("SetUpgradeFalse", 10);
            Destroy(other.gameObject);
        }
        
    }

    private void SetUpgradeFalse()
    {
        isPoweredUp = false;
    }

}

