using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public double defaultHealth = 6;
    private double _health = 6;
    public double health { get { return _health; } }

    private bool isDamageable = true;
   
	// Use this for initialization
	void Start () {
	}

    void Update() {
    }
	
    //Schaden an Chara wird hinzugefügt, durch isDamageable wird der Chara eine Sekunde imun auf Schaden 
	public void ApplyDamage(double damage) {
        if (isDamageable){
            _health -= damage;

            Debug.Log(_health);

            if (_health <= 0) {
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
        if (_health < 6)
        {
            _health++;
        }
        
    }
}
