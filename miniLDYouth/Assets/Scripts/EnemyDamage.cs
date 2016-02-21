using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

    public double defaultDamage = 0.5;
    private double _damage;
    public double damage { get { return _damage; } }


	// Use this for initialization
	void Start () {
        _damage = defaultDamage;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {

        other.gameObject.GetComponentInParent<PlayerHealth>().ApplyDamage(_damage);
    }
}
