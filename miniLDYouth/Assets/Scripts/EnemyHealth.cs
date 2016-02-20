using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float health = 1;
    private Animator anim;
    private float deathtimer = 0;

    void ApplyDemage(float demage){
        health -= demage;

        if (health <= 0){
            Destroy(gameObject);
            //kill();
        }
    }

    //function kill() {
    //   deathtimer ++;
    //    anim.SetBool(,true);
    //    if (deathtimer > 5){
    //        Destroy(enemy);
    //    }
    // }
	
}
