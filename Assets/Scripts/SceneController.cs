using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [ContextMenu("Go to main menu")]
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    [ContextMenu("Go to win screen")]
    public void GoToWinScreen()
    {
        SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
    }

    [ContextMenu("Go to level 1")]
    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    [ContextMenu("Quit game")]
    public void QuitGame()
    {
        Application.Quit();
    }
}
