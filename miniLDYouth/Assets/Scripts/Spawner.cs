using UnityEngine;
using Assets;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {



    public bool debug = true;
    public GameObject spawnedEnemy;
    public double defaultSpawnDelay = 5;
    private double currentSpawnDelay;

    private bool _active;
    /** Status of spawner, spawns when active */
    public bool active
    {
        get
        {
            return _active;
        }
    }
    public bool defaultActive = true;


	// Use this for initialization
	void Start () {
        //TODO: Register at gamecontroller
        currentSpawnDelay = defaultSpawnDelay;
        _active = defaultActive;
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            if (currentSpawnDelay >= 0)
            {
                currentSpawnDelay -= Time.deltaTime;
            }
            else
            {
                spawnEnemy();
            }
        }
	}

    private void spawnEnemy()
    {
        currentSpawnDelay = defaultSpawnDelay;
        Vector3 spawnVector;
        if (debug) {
            spawnVector = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        } else {
            spawnVector = this.transform.position;
        }
        
        //Quaternion playerDirection = Helper.getDirectionToTarget(GameObject.FindGameObjectWithTag("Player").transform.position, spawnVector);
        GameObject newEnemy = (GameObject)Instantiate(spawnedEnemy, spawnVector, new Quaternion());
        newEnemy.transform.parent = GameObject.FindGameObjectWithTag("World").transform;
        newEnemy.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        newEnemy.transform.Rotate(new Vector3(1, 0, 0), 90);
    }
}
