using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ParentEnemyMove : MonoBehaviour
{
    public GameObject player;
    public LineRenderer lineRenderer;
    public Transform playerPos;
    public Rigidbody2D rb;
    public float detectionRange, speed, maxSpeed, speedLoss, timer;
    public bool madeLine, lockMove, canSee;
    public Vector3 movement, distance, goal, directionVector;

    abstract public void OnTriggerEnter(Collider collider);

    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.Find("Player");
        rb = transform.GetComponent<Rigidbody2D>();
    }
    
    public void CanSee()
    {
        int layerMask = 1 << 8;
        if (Physics2D.Raycast(transform.position, distance.normalized, distance.magnitude - 1, layerMask) == false 
            && distance.magnitude < detectionRange)
        {
            canSee = true;
        } else
        {
            canSee = false;
        }
    }

    // Update is called once per frame
    abstract public void FixedUpdate();

    abstract public void Slide(int time);

    public IEnumerator lockMoveTimer(int time)
    {
        yield return new WaitForSecondsRealtime(time);
        lockMove = false;
    }

    public IEnumerator ReasignMove(int time)
    {
        yield return new WaitForSecondsRealtime(time);
        ChooseRandomGoal();
    }

    abstract public void ChooseRandomGoal();

    public void MoveToGoal()
    {
        movement = goal - transform.position;
        movement.Normalize();

        if (!lockMove)
        {
            rb.velocity = movement * speed;
        }
    }

    public void FindPlayer()
    {
        playerPos = player.transform;
        directionVector = (playerPos.position - transform.position);
        distance = directionVector;
        directionVector.Normalize(); //Make direction only not length
    }

    abstract public void Move();

    public int Rand()
    {
        int pos = Random.Range(1, 3);
        pos = (int)Mathf.Pow(-1, pos);
        return pos;
    }
}
