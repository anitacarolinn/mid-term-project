using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    public GameManager gameManager;
    public void StartGame()
    {
        SceneManager.LoadScene("Choose Map");

    }

    public void optionButton()
    {
        SceneManager.LoadScene("Option");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void chooseForest()
    {
        SceneManager.LoadScene("Map Forest");
    }

    public void chooseUnderground()
    {
        SceneManager.LoadScene("Map Underground");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        gameManager.NewGame();
    }
}
