using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public GameObject pauseButton;

    public GameObject pausePanel;

    public GameObject varJoystick;

    public GameObject varJoystickCam;

    public static bool GameIsPaused = false;
   
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    private void Start()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;

    }

    public void Pause()
    {
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
        varJoystick.SetActive(false);
        varJoystickCam.SetActive(false);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        varJoystick.SetActive(true);
        varJoystickCam.SetActive(true);

        Time.timeScale = 1f;
        GameIsPaused = false;
    }


    public void RestartLevel()
    {
        // Retry but show rewarded ad first if available
#if UNITY_2023_2_OR_NEWER
        var adm = UnityEngine.Object.FindFirstObjectByType<AdmobManager>();
#else
        var adm = FindObjectOfType<AdmobManager>();
#endif
        if (adm != null)
        {
            adm.ShowRewardedAd(() => {
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }


    public void LevelMenu()
    {
        //reklam.ShowInterstitialAd();//geçiş reklamı

        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(22);
    }


}
