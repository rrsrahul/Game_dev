using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MO : MonoBehaviour {
    public GameObject cube;


	// Use this for initialization
	void Start () {
        spwancubes(10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void spwancubes(int n)
    {
        int x = 0, z = 0;
        bool isX = false;



        for (int i = 0; i < n; i++)
        {
            //choose a random number
            int num = (int)(Random.Range(0, 2));

            //instasiate the cubes 
            Instantiate(cube, new Vector3(x, cube.transform.position.y, z), Quaternion.identity);
        
            //increment the position 
        if (num == 0)
            {
                x++;
            }
            else
            {
                z++;
           
            }
                

           
        }



    }
}
