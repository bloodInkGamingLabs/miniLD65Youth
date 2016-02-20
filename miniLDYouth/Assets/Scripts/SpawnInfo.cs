using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class SpawnInfo : IInfo
    {
        private GameObject spawnedEnemy;
        public SpawnInfo(GameObject spawnedEnemy)
        {
            this.spawnedEnemy = spawnedEnemy;
        }

        public GameObject getSpawnedEnemy()
        {
            return this.spawnedEnemy;
        }
    }
}
