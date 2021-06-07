using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Difficulty");
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}