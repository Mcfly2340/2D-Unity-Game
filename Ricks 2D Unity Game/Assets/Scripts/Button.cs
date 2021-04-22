using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void IfClickedOnPlay()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void IfClickedOnOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void IfClickedOnQuitGame()
    {
        Application.Quit();
        Debug.Log("Game Ended");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
