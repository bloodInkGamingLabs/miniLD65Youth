﻿using UnityEngine;
using System.Collections;

public class hearthitem : MonoBehaviour {

	

    void OnTriggerEnter(Collider collider){
        Debug.Log("Entered");
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPlayer>().addHealth();
        
        Destroy(gameObject);
    }
    
}
