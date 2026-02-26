using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    public GameObject gameOverPanel;

    //public AdmobManager reklam;

    public static bool GameIsOver=false;


    void Start () {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }
	
	void Update () {
        if (!GameIsOver)
        {
            return;
        }
	}

    public void LevelMenu()
    {
        //reklam.ShowInterstitialAd();//geçiş reklamı

        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(22);
    }


    public void RestartLevel()
    {

        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
