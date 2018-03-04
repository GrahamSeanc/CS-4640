using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBlueAmmo : MonoBehaviour
{
    public ParticleSystem explosion;



    void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.name == "Blue Sphere")
        {
            Debug.Log("Blue Sphere Hit!");
            Fire.blueAmmo += 50;

            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 1))
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
