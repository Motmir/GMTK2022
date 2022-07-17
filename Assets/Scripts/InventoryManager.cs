using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instace = null;

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
        else
        {
            DestroyImmediate(transform.gameObject);
        }
    }

    public Dice activeAttack = null;
    public Dice activeDefence = null;
    public Dice activeUtility = null;

}
