using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    GameObject player;
    public float detectionRange;
    bool madeLine;

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
        //Debug.Log("Dist: " + distance.magnitude);

        if (distance.magnitude < detectionRange && !madeLine)
        {
            madeLine = true;
            LineRenderer lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
            lineRenderer.startColor = Color.black;
            lineRenderer.endColor = Color.black;
            lineRenderer.startWidth = 0.01f;
            lineRenderer.endWidth = 0.01f;
            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;
            lineRenderer.sortingOrder = 1;
            lineRenderer.sortingLayerName = "Entity";

            //For drawing line in the world space, provide the x,y,z values
            lineRenderer.SetPosition(0, transform.position); //x,y and z position of the starting point of the line
            lineRenderer.SetPosition(1, player.transform.position);
            Debug.Log("I see you!");
        }
    }
}
