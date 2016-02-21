using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.up * 200);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
