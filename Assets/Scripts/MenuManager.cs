using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu = null;
    public GameObject InfoMenu = null;
    public GameObject LevelSelect = null;

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
       }

    public void InfoMenuToggle()
    {
        MainMenu.active = !MainMenu.active;
        InfoMenu.active = !InfoMenu.active;
    }

    public void LevelSelectToggle()
    {
        MainMenu.active = !MainMenu.active;
        LevelSelect.active = !LevelSelect.active;
    }

    public void quitTheGame() {
        Debug.Log(" Quit the Game");
        Application.Quit();
    }
}
