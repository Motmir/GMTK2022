using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public int Health;
    public int Shield;
    
    int time = 4;

    public IEnumerator SpeedResetTimer(int time, int amount)
    {
        yield return new WaitForSecondsRealtime(time);
        transform.GetComponent<PlayerControler>().maxSpeed -= amount;   
    }

    public void SpeedUp(int amount) {
        transform.GetComponent<PlayerControler>().maxSpeed += amount;
        StartCoroutine(SpeedResetTimer(time, amount));
    }
   
   

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
