using UnityEngine;
using System.Collections;

public class debugMouseCoordinates : MonoBehaviour {
    public GameObject customObject = null;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        GUIText guitext = GetComponent<GUIText>();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        string text = "Mouse: " + mousePos.ToString() + System.Environment.NewLine;
        text += (customObject!=null ? customObject.ToString() : "") + System.Environment.NewLine;

        guitext.text = text;
        
    }
}
