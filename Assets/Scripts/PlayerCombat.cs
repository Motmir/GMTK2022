using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public int health = 20;
    public int sheild = 0;
    
    public void Damage(int amount)
    {
        var damageLeft = amount;
        while (sheild > 0  && damageLeft > 0)
        {
            sheild -= 1;
            damageLeft -= 1;
        }

        health -= damageLeft;
    }

    public void AddShield(int amount)
    {
        sheild += amount;
    }

    public void AddHealth(int amount)
    {
        health += amount;
    }
}
