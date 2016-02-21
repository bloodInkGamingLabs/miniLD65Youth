using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {
    AudioSource[] audios;

    // Use this for initialization
    void Start () {
        audios = GetComponents<AudioSource>();
        audios[0].Play();
        //audios[1].Play();
    }
	
	// Update is called once per frame
	void Update () {

    }

}
