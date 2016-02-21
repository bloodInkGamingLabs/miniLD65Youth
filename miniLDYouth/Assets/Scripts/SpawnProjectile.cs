using System;
using UnityEngine;
using Assets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;

namespace Assets.Scripts
{
    class SpawnProjectile : MonoBehaviour
    {
        public GameObject spawnedProjectile;
        public float spawnDelay_init = 0.5f;
        private float _spawnDelay;
        private float lastSpawn;// = Time.time;

        public bool canSpawn { get { return Time.time - lastSpawn > _spawnDelay; } }

        public bool isActive
        {
            get
            {
                return Input.GetKey(KeyCode.Mouse0);
            }
        }

        // Use this for initialization
        void Start()
        {
            _spawnDelay = spawnDelay_init;
        }

        // Update is called once per frame
        void Update()
        {
            
            if (isActive && canSpawn)
            {
                Debug.Log("MOUSE DOWN & SPAWNABLE");
                lastSpawn = Time.time;
                spawnProjectile();
            }
        }

        

        private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }
        private void spawnProjectile()
        {
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
            Quaternion newRotation = Quaternion.Euler(new Vector3(90.0f, 0f, angle));



            Vector3 spawnVector = this.transform.position;
            GameObject newProjectile = (GameObject)Instantiate(spawnedProjectile, spawnVector, newRotation);
            newProjectile.transform.parent = GameObject.FindGameObjectWithTag("World").transform;

            //newProjectile.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            //newProjectile.transform.Rotate(new Vector3(1, 0, 0), 90);
            //Rigidbody rgb = newProjectile.GetComponent<Rigidbody>();
            //rgb.AddForce(newProjectile.transform.forward * 20000.0f);
            //rgb.MovePosition(positionOnScreen);

            

            Debug.Log(newProjectile.tag);

        }

    }
}
