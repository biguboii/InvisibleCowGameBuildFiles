using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{
    public GameObject CreditsOBJ;

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        CreditsOBJ.SetActive(true);
        // Show Credits UI
    }
}