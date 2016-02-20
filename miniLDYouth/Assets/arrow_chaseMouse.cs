using UnityEngine;
using System.Collections;

public class arrow_chaseMouse : MonoBehaviour {

    private void chaseMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(90.0f, 0.0f, 0.0f);


        Vector3 diff = mousePosition - transform.parent.localPosition;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        transform.localPosition = Vector3.MoveTowards(transform.parent.position, mousePosition, 5.0f);

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        chaseMouse();
	}
}
