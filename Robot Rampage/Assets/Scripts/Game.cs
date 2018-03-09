using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {



    private static Game Singleton;
    [SerializeField]
    RobotSpawn[] spawns;
    public int enemiesLeft;

	// Use this for initialization
	void Start () {
        Singleton = this;
        SpawnRobots();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SpawnRobots()
    {
        foreach (RobotSpawn spawn in spawns)
        {
            spawn.SpawnRobot();
            enemiesLeft++;
        }
    }
}
