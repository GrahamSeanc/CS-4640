﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticles : MonoBehaviour {

    // Use this for initialization

    private ParticleSystem deathParticles;
    private bool didStart = false;

	void Start () {
        deathParticles = GetComponent<ParticleSystem>();

		
	}
	
	// Update is called once per frame
	void Update () {
        if (didStart && deathParticles.isStopped)
        {
            Destroy(gameObject);
        }
		
	}

    public void Activate()
    {
        didStart = true;
        deathParticles.Play();
    }
    public void SetDeathFloor(GameObject deathfloor)
    {
        if (deathParticles == null) {
            deathParticles = GetComponent<ParticleSystem>();
        }
        deathParticles.collision.SetPlane(0, deathfloor.transform);
    }
}
