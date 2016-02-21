using UnityEngine;
using System.Collections;

public class Weapon_ChaseMouse : MonoBehaviour
{

    private void chaseMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition.Set(mousePosition.x, mousePosition.y, 0.0f);

        //Vector3 diff = new Vector3(mousePosition.x, mousePosition.z, transform.position.z);// - transform.parent.position;
        //diff.Normalize();

        //float rot_z = Mathf.Atan2(diff.x, diff.y) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, rot_z - 90, rot_z - 90.0f);
        //transform.LookAt(Input.mousePosition);

        //transform.position = Vector3.MoveTowards(transform.parent.position, mousePosition, 5.0f);
        transform.position = new Vector3(mousePosition.x, 1.0f, mousePosition.z);





        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.parent.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0f, angle));
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        chaseMouse();
        flipSprite();
    }

    private void flipSprite()
    {
        Transform transf = gameObject.transform;
        if ((transf.rotation.eulerAngles.y > 90 & transf.rotation.eulerAngles.y < 270))
        {
            transf.localScale = new Vector3(transf.localScale.x, -0.31f, transf.localScale.z);
        }
        else
        {
            transf.localScale = new Vector3(transf.localScale.x, 0.31f, transf.localScale.z);
        }
    }
}
