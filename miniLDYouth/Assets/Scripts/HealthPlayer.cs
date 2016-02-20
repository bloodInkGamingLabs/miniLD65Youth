using UnityEngine;
using System.Collections;

public class HealthPlayer : MonoBehaviour {

    public float startHealth = 6;
    private float health = 6;

    private Animator anim;
    private bool isDamageable = true;
   
	// Use this for initialization
	void Start () {
	    anim = GetComponent<Animator>();
	}

    void Update() {
        Debug.Log(health);
    }
	
    //Schaden an Chara wird hinzugefügt, durch isDamageable wird der Chara eine Sekunde imun auf Schaden 
	public void ApplyDamage(float damage) {
        if (isDamageable){
            health -= damage;

            if (health <= 0) {
                Dying();
            }

            isDamageable = false;
            Invoke("ResetIsDamageable", 1);

        }

    }

    private void Dying()
    {
        Debug.Log("I am Dead");
    }

    void ResetIsDamageable()
    {
        isDamageable = true;
    }
   
    public void addHealth(){
        if (health < 6)
        {
            health++;
        }
        
    }
}
