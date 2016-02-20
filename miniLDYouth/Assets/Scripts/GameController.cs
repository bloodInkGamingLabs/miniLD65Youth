using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;
using Assets.Scripts;

public class GameController : MonoBehaviour, Observer {

    List<Observable> observables = new List<Observable>();
    List<Spawner> spawners = new List<Spawner>();
    private double countdown = 1.5;
    private int _maximumSpawns;
    public int maximumSpawns
    {
        get
        {
            return _maximumSpawns;
        }
    }
    public int defaultMaximumSpawns = 10;

    private int spawnedEnemies;

	// Use this for initialization
	void Start () {
        _maximumSpawns = defaultMaximumSpawns;
	}
	
	// Update is called once per frame
	void Update () {
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
        }
        else if(spawnedEnemies < _maximumSpawns)
        {
            foreach (Spawner spawner in spawners) {
                spawner.activate();
            }
        }
	}

    public void addSpawner(Spawner spawner)
    {
        spawners.Add(spawner);
    }

    public void getInfo(IInfo info)
    {
        if (info.GetType().Equals(typeof(SpawnInfo)))
        {
            SpawnInfo sInfo = (SpawnInfo) info;
            if (sInfo.getSpawnedEnemy() != null)
            {
                this.spawnedEnemies++;
                if (spawnedEnemies >= _maximumSpawns)
                {
                    foreach (Spawner spawner in spawners)
                    {
                        spawner.deactivate();
                    }
                }
            }
        }
    }
}
