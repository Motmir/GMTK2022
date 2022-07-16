using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu = null;
    public GameObject InfoMenu = null;
      public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void InfoMenuToggle()
    {
        MainMenu.active = !MainMenu.active;
        InfoMenu.active = !InfoMenu.active;
    }

    public void quitTheGame() {
        Debug.Log(" Quit the Game");
        Application.Quit();
    }
}
