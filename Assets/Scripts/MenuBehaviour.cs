using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    public GameObject mInstructionsPanel;
    public GameObject mMenuPanel;

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void OnInstructionsButtonPressed()
    {
        if (mInstructionsPanel.gameObject.activeSelf == false)
        {
            mInstructionsPanel.gameObject.SetActive(true);
            mMenuPanel.gameObject.SetActive(false);
        }
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    public void OnBackButtonPressed()
    {
        if (mInstructionsPanel.gameObject.activeSelf == true)
        {
            mInstructionsPanel.gameObject.SetActive(false);
            mMenuPanel.gameObject.SetActive(true);
        }
    }
}
