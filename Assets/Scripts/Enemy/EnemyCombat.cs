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


    override public void Slow(int amount)
    {
        StartCoroutine(waiter());
        IEnumerator waiter()
        {
            this.GetComponent<EnemyMovement>().speed = (this.GetComponent<EnemyMovement>().maxSpeed - amount);

            yield return new WaitForSecondsRealtime(3);

            this.GetComponent<EnemyMovement>().speed = this.GetComponent<EnemyMovement>().maxSpeed;
        }
    }
}
