using UnityEngine;
using System.Collections;

public class debugMouseCoordinates : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        GUIText guitext = GetComponent<GUIText>();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        string text = "Mouse: X: " + mousePos.x + " | Y: " + mousePos.y + " | Z: " + mousePos.z + System.Environment.NewLine;
        text += "";



        guitext.text = text;
        
    }
}
