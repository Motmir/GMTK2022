using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneByButton : MonoBehaviour
{
      public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void quitTheGame() {
        Debug.Log(" Quit the Game");
        Application.Quit();
    }
}
