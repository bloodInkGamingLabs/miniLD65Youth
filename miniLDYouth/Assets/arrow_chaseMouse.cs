using UnityEngine;
using System.Collections;

public class arrow_chaseMouse : MonoBehaviour {

    private void chaseMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        Vector3 diff = mousePosition - transform.parent.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        transform.position = Vector3.MoveTowards(transform.parent.position, mousePosition, 5.0f);

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        chaseMouse();
	}
}
