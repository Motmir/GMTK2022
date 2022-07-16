using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Attributes
    GameObject player;
    LineRenderer lineRenderer;
    Rigidbody2D rb;
    public float detectionRange, speed, maxSpeed, speedLoss, timer;
    bool madeLine;
    Vector3 movement, distance, goal;

    public void OnTriggerEnter(Collider collider)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FindPlayer();
    }

    void MoveToGoal()
    {
        movement = goal - transform.position;
        movement.Normalize();

        rb.velocity = movement * speed;
    }

    void FindPlayer()
    {
        distance = player.transform.position - transform.position;
        distance.z = 0;

        if (distance.magnitude < detectionRange && !madeLine)
        {
            madeLine = true;
            lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
            lineRenderer.startColor = Color.black;
            lineRenderer.endColor = Color.black;
            lineRenderer.startWidth = 0.01f;
            lineRenderer.endWidth = 0.01f;
            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;
            lineRenderer.sortingOrder = 1;
            lineRenderer.sortingLayerName = "Entity";
        }
        
        int layerMask = 1 << 8;
        if (distance.magnitude < detectionRange && Physics2D.Raycast(transform.position, distance.normalized, distance.magnitude - 1, layerMask) == false)
        {
            if (Physics2D.Raycast(transform.position, distance.normalized, distance.magnitude - 1, layerMask) == false)
            {
                timer = 3;
                goal = player.transform.position;
                MoveToGoal();
                lineRenderer.SetPosition(0, transform.position); 
                lineRenderer.SetPosition(1, player.transform.position);
            }
        } else
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                goal = new Vector3(
                    (transform.position.x + Random.Range(10, 20)) * Rand(), 
                    (transform.position.y + Random.Range(10, 20)) * Rand(), 0);
                MoveToGoal();
                timer = 3;
            }
        }
        
    }

    int Rand()
    {
        int pos = Random.Range(1, 3);
        pos = (int)Mathf.Pow(-1, pos);
        return pos;
    }
}
