using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float health = 1;
    private Animator anim;
    

    void ApplyDemage(float demage){
        health -= demage;

        if (health <= 0){
            Destroy(gameObject);
        }
    }

    
}
