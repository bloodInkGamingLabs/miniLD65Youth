using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	private double _health;
    public double health { get { return _health; } }
    public double defaultHealth = 1;

    public void ApplyDamage(double damage){
        _health -= damage;
        if (_health <= 0)
        {
            die();
        }
    }

    void Start()
    {
        _health = defaultHealth;
    }

    void Update()
    {
    }

    private void die()
    {
        Destroy(gameObject);
    }

    
}
