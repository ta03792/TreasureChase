using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void Continue()
    {
        SceneManager.LoadScene("MainScreen");
    }
    public void NewGame()
    {
        SceneManager.LoadScene("CharacterScreen");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
   
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void MainScreen()
    {
        SceneManager.LoadScene("MainScreen");
    }

    public void ExitScreen()
    {
        Application.Quit();
    }
}