using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRedAmmo : MonoBehaviour
{
    public ParticleSystem explosion;
    //public AudioSource explodeSound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Red Sphere")
        {
            Debug.Log("redSphere Hit!");
            Fire.redAmmo += 50;

            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 10))
            {
                Vector3 reflectV = Vector3.Reflect(transform.forward, hit.normal);
                transform.position = hit.point;
                transform.rotation = Quaternion.LookRotation(reflectV);
            }
            
        }
        else
        {
            Explode(transform.position);
            Destroy(gameObject);
            Debug.Log("explode!");
        }
    }
    public void Explode(Vector3 position)
    {
        Instantiate(explosion, position, Quaternion.identity);
    }
}