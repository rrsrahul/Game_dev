using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        AudioManager.Instance.asCoin.Play();
       
        GameManager.instance.Addscore(5);
        Destroy(gameObject);


    }

    
}
