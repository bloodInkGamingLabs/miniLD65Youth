using UnityEngine;
using System.Collections;

public class Weapon_ChaseMouse : MonoBehaviour
{

    private void chaseMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition.Set(mousePosition.x, mousePosition.y, 0.0f);

        Vector3 diff = new Vector3(mousePosition.x, mousePosition.z, transform.position.z) - transform.parent.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.x, diff.y) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, rot_z - 90, rot_z - 90.0f);
        //transform.LookAt(Input.mousePosition);

        //transform.position = Vector3.MoveTowards(transform.parent.position, mousePosition, 5.0f);
        transform.localPosition = new Vector3(mousePosition.x, mousePosition.z, transform.position.z);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        chaseMouse();
    }
}
