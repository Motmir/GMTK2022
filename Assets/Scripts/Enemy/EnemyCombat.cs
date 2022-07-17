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
            //GameObject enemy = (GameObject)Resources.Load("Enemy");
            //GameObject bulletTransform = GameObject.Instantiate(enemy, new Vector3(0,0,0), Quaternion.identity);
        }
    }

    public override void Slide(int time)
    {
        EnemyMovement enmMove = transform.GetComponent<EnemyMovement>();
        enmMove.Slide(time);
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
