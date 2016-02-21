using UnityEngine;
using System.Collections;

public class Ente_Animator : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(this.transform.parent.parent.gameObject.GetComponent<EnemyHealth>().health <= 0)
        {
            this.GetComponent<Animator>().SetTrigger("Dies");
        }*/
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("KOLLISION: " + collision.collider.ToString());
        if (collision.collider.Equals(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>()))
        {
            //Fight_Start
            this.GetComponent<Animator>().ResetTrigger("Fight_End");
            this.GetComponent<Animator>().SetTrigger("Fight_Start");
            
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.Equals(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>()))
        {
            //Fight_End
            this.GetComponent<Animator>().ResetTrigger("Fight_Start");
            this.GetComponent<Animator>().SetTrigger("Fight_End");
        }
    }
}
