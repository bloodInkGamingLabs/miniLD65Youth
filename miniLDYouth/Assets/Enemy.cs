using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//follow Player
        GetComponentInChildren<NavMeshAgent>().destination = player.transform.position;
        flipSprite();
	}

    private void flipSprite()
    {
        if (gameObject.transform.rotation.eulerAngles.y > 180)
        {
            gameObject.transform.localScale = new Vector3(1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }


}
