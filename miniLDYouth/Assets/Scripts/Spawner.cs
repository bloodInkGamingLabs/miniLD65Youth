using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

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
        GameObject newEnemy = (GameObject)Instantiate(spawnedEnemy, new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), new Quaternion());
        //GameObject newEnemy = (GameObject) Instantiate(spawnedEnemy, this.transform.position, new Quaternion());
        newEnemy.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }
}
