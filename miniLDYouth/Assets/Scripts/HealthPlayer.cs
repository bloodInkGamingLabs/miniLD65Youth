using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float startHealth = 6;
    private float health = 6;

    private Animator anim;
    private bool isDamageable = true;
   
	// Use this for initialization
	void Start () {
	    anim = GetComponent<Animator>();
	}
	
    //Schaden an Chara wird hinzugefügt, durch isDamageable wird der Chara eine Sekunde imun auf Schaden 
	void ApplyDamage(float damage) {
        if (isDamageable == true){
            health -= damage;

            if (health <= 0) {
                Dying();
            }

            isDamageable = false;
            Invoke("ResetIsDamageable", 1);

        }

    }

    void ResetIsDamageable()
    {
        isDamageable = true;
    }

    //nach Tod wird das Level neu geladen
    void Dying()
    {
        anim.SetBool("Dying", true);
        RestardLevel();
    }

    void RestardLevel()
    {
        health = startHealth;
        anim.SetBool("Dying", false);
    }

    public void addHealth(){
        health++;
    }
}
