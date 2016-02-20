using UnityEngine;
using System.Collections;

public class turnTowardsMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.Set(mousePosition.x, mousePosition.y, 0.0f);

        Vector3 diff = mousePosition - transform.parent.position + new Vector3(90.0f, 0, 0);
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.z) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, rot_z - 90, rot_z - 90.0f);
    }
}
