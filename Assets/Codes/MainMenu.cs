using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(22);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PrivacyPolicy()
    {
        Application.OpenURL("https://gist.githubusercontent.com/kayasibel/8f17ac9b58be8e1b8e46fe99d0e28155/raw/0e798276d5432df4357c9133d6dbdda349afdd34/privacy-policy.md");
    }

    public void RateUs()
    {
	Application.OpenURL("http://play.google.com/store/apps/details?id=com.SibelKaya.Ballance3D");
    }
}
