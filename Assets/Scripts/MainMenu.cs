using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        AudioManager.Instance.Stop("MenuTheme");
        AudioManager.Instance.Play("MainTheme");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
