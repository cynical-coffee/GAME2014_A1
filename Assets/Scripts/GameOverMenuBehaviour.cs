using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuBehaviour : MonoBehaviour
{
    public void OnPlayAgainButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void OnQuitButtonPress()
    {
        Application.Quit();
    }
}
