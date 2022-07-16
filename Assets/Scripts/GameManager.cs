using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private void OnLevelWasLoaded(int level)
    {
        InventoryManager.instace.activeAttack = new Dice(new Dice.enumFace[] {  Dice.enumFace.FireballFace, Dice.enumFace.EmptyFace });
        InventoryManager.instace.activeDefence = new Dice(new Dice.enumFace[] {  Dice.enumFace.IceFace, Dice.enumFace.EmptyFace });
        InventoryManager.instace.activeUtility = new Dice(new Dice.enumFace[] {  Dice.enumFace.VineFace, Dice.enumFace.HealFace });
        Debug.Log(InventoryManager.instace.activeAttack);
    }
}
