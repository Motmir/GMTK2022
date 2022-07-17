using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (health <= 0 )
        {
            Destroy(gameObject);
            StartCoroutine(lockMoveTimer(3));
        }
    }

    public IEnumerator lockMoveTimer(int time)
    {
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene("Mainmenu");
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
