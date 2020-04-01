using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;
    public AudioSource asMusic;
    public AudioSource asCoin;

    

	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
