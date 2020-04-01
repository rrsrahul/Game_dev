using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public Transform coin;
    public bool ispaused = false;
    public Transform cube ;
    public List<Transform> cubes;
    public RectTransform gameplaypanel;
    int x = 0, z = 0;
    int score = 0;
   public int highestscore = 0;
    int nextcoin;
    public int a=0;

    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
        
        if (PlayerPrefs.HasKey("score"))
        { highestscore = PlayerPrefs.GetInt("score"); }

        loadscore();
        cubes = new List<Transform>();
        CoinSpawnRandom();
        SpawnCubes(3,false);
        SpawnCubes(22, true);
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

public void StopTime()
    {
        ispaused = true;

    }
    public void ResumeTime()
    {
        ispaused = false;

    }
    public void SpawnCubes(int n,bool isRandom)
    {
        int num;
        a++;
        for (int i = 0; i < n; i++)
        {
            //choose a random direction
            if (isRandom)
            { num = (int)Random.Range(0, 2); }
            else
            { num = 0; }
            /* if(i%2==0)
             * num=0;
             * else
             * num=1;
             * */
            // instanstiate a cube there
            Transform tr = Instantiate(cube, new Vector3(x, cube.transform.position.y,z), Quaternion.identity);
            cubes.Add(tr);
            nextcoin--;
            if(nextcoin==0)
            {
                //spawn the coin
                Instantiate(coin, new Vector3(x, cube.transform.position.y + 0.75f, z), Quaternion.identity);





                CoinSpawnRandom();

            }

            //increment the position...  
            if (num == 0)
            {
                x--;
            }
            else
            {
                z++;
            }
        }
    }
    public void Addscore(int n)
    {
        score += n;
        UImanager.instance.scoretext.text = score.ToString();
    }

    public void savescore()
    {
        if (highestscore < score)
        {//save 
            highestscore = score;
            PlayerPrefs.SetInt("score", score);
        }
        
    }
    public void CoinSpawnRandom()
    {
        nextcoin = Random.Range(3, 10);

    }
    public void loadscore()
    {
        if (highestscore < score)
        {
             PlayerPrefs.SetInt("score", score);
        }

    }
public void ReloadScene()
    {
        SceneManager.LoadScene("rrs");
    }
    }

