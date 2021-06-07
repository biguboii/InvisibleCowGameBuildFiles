using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playagain : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Submit")) {
            SceneManager.LoadScene("Gameplay_Scene");
            Cursor.visible = false;
        }
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Main_Menu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
