using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public int Health;
    public int Shield;
    
    public void Damage(int amount)
    {
        var damageLeft = amount;
        while (Shield > 0  && damageLeft > 0)
        {
            Shield -= 1;
            damageLeft -= 1;
        }

        Health -= damageLeft;
    }

    public void AddShield(int amount)
    {

    }

    public void AddHealth(int amount)
    {

    }
}
