using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : ParentEnemyCombat
{


    override public void Damage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    override public void Slow(int amount, int time)
    {
        StartCoroutine(waiter(amount, time));
    }
    IEnumerator waiter(int amount, int time)
    {
        Debug.Log("Speed: " + this.GetComponent<EnemyMovement>().speed);
        Debug.Log("Time: " + time);
        this.GetComponent<EnemyMovement>().speed = (this.GetComponent<EnemyMovement>().maxSpeed - amount);
        Debug.Log("NewSpeed: " + this.GetComponent<EnemyMovement>().speed);
        yield return new WaitForSecondsRealtime(time);

        this.GetComponent<EnemyMovement>().speed = this.GetComponent<EnemyMovement>().maxSpeed;
    }
}
