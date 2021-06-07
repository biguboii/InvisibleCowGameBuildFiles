using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogIn : MonoBehaviour
{
    public TextMeshProUGUI UserName , Password;
    public TextMeshProUGUI IncorrectShow;

    public void LogInButton()
    {
        if (string.Compare(UserName.text, "Test") == 1)
        {
            if (string.Compare(Password.text, "1234") == 1)
            {
                // Congrats
                IncorrectShow.transform.parent.gameObject.SetActive(true);
                IncorrectShow.text = "Welcome";
            }
            else
            {
                IncorrectShow.transform.parent.gameObject.SetActive(true);
                IncorrectShow.text = "Incorrect Password";
            }
        }
        else
        {
            IncorrectShow.transform.parent.gameObject.SetActive(true);
            IncorrectShow.text = "Incorrect UserName";
        }
    }
}
