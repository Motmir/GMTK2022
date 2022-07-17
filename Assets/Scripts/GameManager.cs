using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instace = null;

    public PlayerControler playerControler = null;


    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        playerControler.Rebind();

        switch (scene.name)
        {
            case "Floor1":
                InventoryManager.instace.activeAttack = new Dice(new Dice.enumFace[] { Dice.enumFace.FireballFace, Dice.enumFace.EmptyFace });
                InventoryManager.instace.activeDefence = new Dice(new Dice.enumFace[] { Dice.enumFace.IceFace, Dice.enumFace.EmptyFace });
                InventoryManager.instace.activeUtility = new Dice(new Dice.enumFace[] { Dice.enumFace.VineFace, Dice.enumFace.HealFace });
                break;
            case "Floor2":
                InventoryManager.instace.activeAttack = new Dice(new Dice.enumFace[] { Dice.enumFace.FireballFace, Dice.enumFace.EmptyFace });
                InventoryManager.instace.activeDefence = new Dice(new Dice.enumFace[] { Dice.enumFace.IceFace, Dice.enumFace.EmptyFace });
                InventoryManager.instace.activeUtility = new Dice(new Dice.enumFace[] { Dice.enumFace.VineFace, Dice.enumFace.HealFace });
                break;
            case "Floor3":
                InventoryManager.instace.activeAttack = new Dice(new Dice.enumFace[] { Dice.enumFace.FireballFace, Dice.enumFace.EmptyFace });
                InventoryManager.instace.activeDefence = new Dice(new Dice.enumFace[] { Dice.enumFace.IceFace, Dice.enumFace.EmptyFace });
                InventoryManager.instace.activeUtility = new Dice(new Dice.enumFace[] { Dice.enumFace.VineFace, Dice.enumFace.HealFace });
                break;
            case "Floor4":
                InventoryManager.instace.activeAttack = new Dice(new Dice.enumFace[] { Dice.enumFace.FireballFace, Dice.enumFace.EmptyFace });
                InventoryManager.instace.activeDefence = new Dice(new Dice.enumFace[] { Dice.enumFace.IceFace, Dice.enumFace.EmptyFace });
                InventoryManager.instace.activeUtility = new Dice(new Dice.enumFace[] { Dice.enumFace.VineFace, Dice.enumFace.HealFace });
                break;
            case "Floor5":
                InventoryManager.instace.activeAttack = new Dice(new Dice.enumFace[] { Dice.enumFace.FireballFace, Dice.enumFace.EmptyFace });
                InventoryManager.instace.activeDefence = new Dice(new Dice.enumFace[] { Dice.enumFace.IceFace, Dice.enumFace.EmptyFace });
                InventoryManager.instace.activeUtility = new Dice(new Dice.enumFace[] { Dice.enumFace.VineFace, Dice.enumFace.HealFace });
                break;
            case "Floor6":
                InventoryManager.instace.activeAttack = new Dice(new Dice.enumFace[] { Dice.enumFace.FireballFace, Dice.enumFace.EmptyFace });
                InventoryManager.instace.activeDefence = new Dice(new Dice.enumFace[] { Dice.enumFace.IceFace, Dice.enumFace.EmptyFace });
                InventoryManager.instace.activeUtility = new Dice(new Dice.enumFace[] { Dice.enumFace.VineFace, Dice.enumFace.HealFace });
                break;
            case "Floor7":
                InventoryManager.instace.activeAttack = new Dice(new Dice.enumFace[] { Dice.enumFace.FireballFace, Dice.enumFace.EmptyFace });
                InventoryManager.instace.activeDefence = new Dice(new Dice.enumFace[] { Dice.enumFace.IceFace, Dice.enumFace.EmptyFace });
                InventoryManager.instace.activeUtility = new Dice(new Dice.enumFace[] { Dice.enumFace.VineFace, Dice.enumFace.HealFace });
                break;
            case "mainMenu":
                Debug.Log("delete GameManager plz");
                DestroyImmediate(gameObject);
                break;
            default:
                Debug.LogError("scene is not spessefied in switchcase for GameManager");
                break;
        }




    }
}
