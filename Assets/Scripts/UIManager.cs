using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    private static UIManager instace= null;

    public static bool paused = false;
    public GameObject pauseMenu = null;

    public SpriteRenderer offenceDie = null;
    public SpriteRenderer defenceDie = null;
    public SpriteRenderer utilityDie = null;

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        } else
        {
            DestroyImmediate(transform.gameObject);
        }
    }

    public void TogglePause()
    {
        pauseMenu.SetActive(!pauseMenu.active);
        Debug.Log(pauseMenu.active);
        if (pauseMenu.active)
        {
            Time.timeScale = 0;
            paused = true;
        } else
        {
            Time.timeScale = 1;
            paused = false;
        }
    }

    private void Update()
    {
        offenceDie.sprite = InventoryManager.instace.activeAttack.getFace().GetSprite();
        defenceDie.sprite = InventoryManager.instace.activeDefence.getFace().GetSprite();
        utilityDie.sprite = InventoryManager.instace.activeUtility.getFace().GetSprite();
    }



}
