using UnityEngine;
using Assets;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class Spawner : MonoBehaviour, Observable {



    public bool debug = true;
    public GameObject spawnedEnemy;
    public double defaultSpawnDelay = 5;
    private double currentSpawnDelay;
    private List<Observer> observers = new List<Observer>();
    private GameController gameController;

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
        //_active = defaultActive;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        this.addObserver(gameController);
        gameController.addSpawner(this);
	}
	
	// Update is called once per frame
	void Update () {
        if (_active)
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
        
        GameObject newEnemy = (GameObject) Instantiate(spawnedEnemy, spawnVector, new Quaternion());
        newEnemy.transform.parent = GameObject.FindGameObjectWithTag("World").transform;
        newEnemy.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        newEnemy.transform.Rotate(new Vector3(1, 0, 0), 90);
        this.informObserver(new SpawnInfo(newEnemy));
    }

    private void informObserver(SpawnInfo spawnInfo)
    {
        foreach (Observer observer in observers)
        {
            observer.getInfo(spawnInfo);
        }
    }

    public bool addObserver(Observer observer)
    {
        observers.Add(observer);
        return true;
    }

    internal void activate()
    {
        this._active = true;
    }

    internal void deactivate()
    {
        Debug.Log("Deactivated");
        this._active = false;
    }
}
