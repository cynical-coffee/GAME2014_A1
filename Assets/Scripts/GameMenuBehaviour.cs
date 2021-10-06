using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuBehaviour : MonoBehaviour
{
    public GameObject mPausePanel;

    public void OnPauseButtonPressed()
    {
        if (mPausePanel.gameObject.activeSelf == false)
        {
            mPausePanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void OnResumeButtonPressed()
    {
        if (mPausePanel.gameObject.activeSelf == true)
        {
            mPausePanel.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void OnQuitButtonPress()
    {
        SceneManager.LoadScene(2);
    }
}
