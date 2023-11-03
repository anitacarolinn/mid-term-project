using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisappearUI : MonoBehaviour
{
    public Button MainMenuButton;
    public Button RestartButton;

    public void disappearUIbutton()
    {
        MainMenuButton.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
    }

    public void showUIbutton()
    {
        MainMenuButton.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }

}
