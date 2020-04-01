using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

    public static UImanager instance;

    public RectTransform StartMenuPanel;

    public RectTransform pauseMenuPanel;

    public RectTransform EndPanel;

    public Text scoretext;

    public RectTransform gameplayPanel;

    public Text EndpanelScoretext;

    public Text Endpanelbesttext;
    // Use this for initialization
    void Start()
    {

        instance = this;
        if (PlayerPrefs.HasKey("IsRestart") && PlayerPrefs.GetInt("IsRestart") == 1)
        {
            //restart button
        }
        else
        {
            //display Home button
            //stop time
            GameManager.instance.StopTime();
            //show start menu panel
            StartMenuPanel.gameObject.SetActive(true);
        }
        scoretext.text = "0";

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPauseButton()
    {

        pauseMenuPanel.gameObject.SetActive(true);
        GameManager.instance.StopTime();
        AudioManager.Instance.asMusic.Pause();



    }
    public void OnResumeButton()
    {
        pauseMenuPanel.gameObject.SetActive(false);
        StartMenuPanel.gameObject.SetActive(false);
        AudioManager.Instance.asMusic.Play();
        GameManager.instance.ResumeTime();
    }

    public void OnRestartButton()
    {
        PlayerPrefs.SetInt("IsRestart", 1);
        GameManager.instance.ReloadScene();
        
    }

    public void OnHomeButton()
    {

        PlayerPrefs.SetInt("IsRestart", 0);
        GameManager.instance.ReloadScene();
    }


    
}
