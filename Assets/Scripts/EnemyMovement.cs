using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    GameObject player;
    public float detectionRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RandomMovement();
        FindPlayer();
    }

    void RandomMovement()
    {

    }

    void FindPlayer()
    {
        Vector3 distance = player.transform.position - transform.position;

        if (distance.magnitude < detectionRange)
        {
            Debug.Log("I see you!");
        }
    }
}
