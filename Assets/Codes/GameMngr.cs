using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
// Reflection no longer needed


public class GameMngr : MonoBehaviour {

    public SceneFader sceneFader;

    public string nextLevel = "Scene1";

    public int levelToUnlock = 2;

    public int timeLeft = 5;
    public Text countDownText;

    public GameObject gameOverPanel;

    public GameObject pauseButton;

    public Text extraTime;

    public GameObject varJoystick;
    public GameObject varJoystickCam;

    void Start()
    {      
        gameOverPanel.SetActive(false);
        StartCoroutine("LoseTime");

    }

    void Update()
    {

        countDownText.text = ("TIME : " + timeLeft);
        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countDownText.text = "TIME UP";
            GameOver();
        }
    }

    public void EkZaman()
    {
        StartCoroutine("ExtraTime");
        extraTime.text = "Time +5";

    }


    public void WinLevel()
    {
        // Ödüllü reklamı göster
#if UNITY_2023_2_OR_NEWER
        var adm = UnityEngine.Object.FindFirstObjectByType<AdmobManager>();
#else
        var adm = FindObjectOfType<AdmobManager>();
#endif
        if (adm != null)
        {
            adm.ShowRewardedAd(() => {
                if (levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
                {
                    PlayerPrefs.SetInt("levelReached", levelToUnlock);
                }
                sceneFader.FadeTo(nextLevel);
            });
        }
        else
        {
            if (levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
            {
                PlayerPrefs.SetInt("levelReached", levelToUnlock);
            }
            sceneFader.FadeTo(nextLevel);
        }
    }

    // No helper needed

    public void GameOver()
    {
       // reklam.ShowInterstitialAd();//geçiş reklamı
        varJoystick.SetActive(false);
        varJoystickCam.SetActive(false);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }


    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

    IEnumerator ExtraTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            extraTime.text = "";
            StopCoroutine("ExtraTime");

        }
    }

}
