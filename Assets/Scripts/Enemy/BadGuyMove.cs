using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyMove : ParentEnemyMove
{
    public override void FixedUpdate()
    {
        FindPlayer();
        CanSee();
        Move();
        MoveToGoal();
    }

    public override void Move()
    {
        if (canSee)
        {
            float goalDistance = (detectionRange * 3) / 4;
            goal = directionVector * goalDistance;
        } 
        else
        {
            ChooseRandomGoal();
            StartCoroutine(ReasignMove(3));
        }
    }

    public override void ChooseRandomGoal()
    {
        goal = new Vector3(
                    (transform.position.x + Random.Range(10, 20)) * Rand(),
                    (transform.position.y + Random.Range(10, 20)) * Rand(), 0);
    }

    public override void OnTriggerEnter(Collider collider)
    {
        throw new System.NotImplementedException();
    }

    public override void Slide(int time)
    {
        throw new System.NotImplementedException();
    }
}
