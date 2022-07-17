using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyMove : ParentEnemyMove
{
    Animator baddudeanim;
    public override void FixedUpdate()
    {
        FindPlayer();
        CanSee();
        Move();
        MoveToGoal();
    }
    private void Awake()
    {
        baddudeanim = GetComponent<Animator>();
     
    }
    public override void Move()
    {
        if (canSee)
        {
            float goalDistance = (detectionRange * 3) / 4;

            baddudeanim.SetBool("RunSide", true);
            if(Mathf.Abs(directionVector.x) > Mathf.Abs(directionVector.y))
            {
                baddudeanim.SetBool("RunSide", true);
                baddudeanim.SetBool("RunUp", false);
                baddudeanim.SetBool("RunDown", false);
            }
            else if (directionVector.y > 0)
            {
                baddudeanim.SetBool("RunSide", false);
                baddudeanim.SetBool("RunUp", true);
                baddudeanim.SetBool("RunDown", false);
            }
            else if (directionVector.y < 0)
            {
                baddudeanim.SetBool("RunSide", false);
                baddudeanim.SetBool("RunUp", false);
                baddudeanim.SetBool("RunDown", true);
            }

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
