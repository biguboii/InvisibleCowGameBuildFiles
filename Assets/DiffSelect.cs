using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiffSelect : MonoBehaviour
{
    public void Easy()
    {
        PlayerPrefs.SetString("Difficulty", "Easy");
        Cursor.visible = false;
        SceneManager.LoadScene("Gameplay_Scene");
    }

    public void Medium()
    {
        PlayerPrefs.SetString("Difficulty", "Medium");
        Cursor.visible = false;
        SceneManager.LoadScene("Gameplay_Scene");
    }

    public void Hard()
    {
        PlayerPrefs.SetString("Difficulty", "Hard");
        Cursor.visible = false;
        SceneManager.LoadScene("Gameplay_Scene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
