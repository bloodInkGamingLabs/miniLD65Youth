using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	private double _health;
    public double health { get { return _health; } }
    public double defaultHealth = 1;

    public void ApplyDamage(double damage){
        _health -= damage;
    }

    void Start()
    {
        _health = defaultHealth;
    }

    void Update()
    {
        if (_health <= 0)
        {
            die();
        }
    }

    private void die()
    {
        Destroy(gameObject);
    }

    
}
