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

		//TODO: next 5 lines are copied from player to prevent rotation, we should try to correct the rotation once in start() instead
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 diff = mousePosition - transform.parent.localPosition;
		diff.Normalize();		
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.localRotation = Quaternion.Euler(0f, 0f, rot_z - 90);
		

		//follow Player
		Vector3 playerPos = player.transform.position;
		playerPos.Set (playerPos.x, transform.position.y, playerPos.z);
		GetComponent<NavMeshAgent> ().destination = playerPos;
	}
}
