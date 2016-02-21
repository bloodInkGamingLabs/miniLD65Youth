using UnityEngine;
using System.Collections;

public class ProjectileDamage : MonoBehaviour {

    private double _damage;
    public double damage { get { return _damage; } }
    public double defaultDamage = 1;

	// Use this for initialization
	void Start () {
        _damage = defaultDamage;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider otherCollider)
    {
        EnemyHealth enemy = otherCollider.gameObject.GetComponentInParent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.ApplyDamage(this._damage);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Borders")) {
            Invoke("selfDestruct", 1);
        }
    }

    void selfDestruct()
    {
        Destroy(gameObject);
    }
}
