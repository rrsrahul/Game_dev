using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BALLMOVER : MonoBehaviour
{
    Transform player;
    Vector3 ballpos;
    bool isRight;
    bool isEntered;
    Rigidbody rb;
    float endgametimer = 1f;
    bool endgametimerenabled = false;
    


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Transform>();
       }

    // Update is called once per frame
    void Update()
    {
        if(endgametimerenabled==true)
        {
            endgametimer -= 0.05f;


        }
         if(endgametimer<=0)
        {
            //pause the game
            GameManager.instance.StopTime();

            UImanager.instance.EndPanel.gameObject.SetActive(true);
            endgametimer = 1f;
            endgametimerenabled = false;
            //show the end panel
        }

        if (GameManager.instance.ispaused == false)
        {
            //moving the ball
            
            ballpos = player.position;
         
                if (isRight == true)
            {
                ballpos.z += 0.025f;
                
            }
            else
            {
                 ballpos.x-= 0.025f;
             

            }
            player.position = ballpos;
            //enable bgbutton..
            GameManager.instance.gameplaypanel.gameObject.SetActive(true);
        }
        else
        {
            GameManager.instance.gameplaypanel.gameObject.SetActive(false);
        }
    }
    public void MainButtonClicked()
    {
        isRight = !isRight;
    }

    public void OnTriggerExit(Collider other)// works when the istrigger is on for the cube
    {
        if (isEntered == true)
        {
            GameManager.instance.SpawnCubes(1,true);

            if (GameManager.instance.cubes.Count >= 30)
            {
                Transform t = GameManager.instance.cubes[0];
                GameManager.instance.cubes.RemoveAt(0);
                Destroy(t.gameObject);
            }

            GameManager.instance.Addscore(1);
        }
        else
        {
            //player needs to fall
            rb.isKinematic = false;

        }
        isEntered = false;
    }
    public void OnTriggerEnter(Collider other)//works when the istrigger is on for the cube
    {
        isEntered = true;
    }

    public void OnCollisionEnter(Collision collision)// works when two colliders meet
    {
        //only if it hits the plane
        if(collision.gameObject.tag=="Plane")//collison stores information about the game object and can be acsessed
        {
            GameManager.instance.gameplaypanel.gameObject.SetActive(false);
            //disable bg button

            endgametimerenabled = true;

            //update score in endGamepanel
            UImanager.instance.EndpanelScoretext.text = "Score: " + UImanager.instance.scoretext.text;

          

            //save score
            GameManager.instance.savescore();

            //update best score in end panel
            UImanager.instance.Endpanelbesttext.text = " Best Score: " + GameManager.instance.highestscore.ToString();

        }

    }

  
}



