using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void IfClickedOnPlay()
    {
        SceneManager.LoadScene("Game");
    }
    public void IfClickedOnOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
