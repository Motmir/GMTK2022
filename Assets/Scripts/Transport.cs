using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transport : MonoBehaviour
{
    public void LoadNextScene()
    {
        Debug.Log("Transporting to: " + SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit: " + col.gameObject.name);
        if (col.gameObject.name == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
