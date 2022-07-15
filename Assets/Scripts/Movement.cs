using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    //Values
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private Vector2 moveVector;
    private Vector3 currMove;
    
    //Attributes
    public float speed;
    public float maxSpeed;
    public float speedLoss;
    public float speedCutoff;

    //Booleans
    int xMod;
    int yMod;

    //[SerializeField] private LayerMask PlatformLayermask;

    private void Awake() {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 144;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMove();
    }

    private void playerMove() 
    {
        if (moveVector.x > 0) //Check if move right or left
        {
            xMod = 1;
        } else if (moveVector.x < 0)
        {
            xMod = -1;
        }

        if (moveVector.y > 0) //Check if move up or down
        {
            yMod = 1;
        } else if (moveVector.y < 0)
        {
            yMod = -1;
        }


        float speedY = Mathf.Abs(moveVector.y) * speed;
        float speedX = Mathf.Abs(moveVector.x) * speed;

        Vector3 movement = new Vector3(
            speedX * xMod, //x
            speedY * yMod, //y
            0 //z
            );

        currMove = currMove + movement;

        int curX;
        int curY;

        if (currMove.x >= 0)
        {
            curX = 1;
        } else
        {
            curX = -1;
        }
        
        if (currMove.y >= 0)
        {
            curY = 1;
        }
        else
        {
            curY = -1;
        }

        if (moveVector.x == 0)
        {
            Debug.Log("Input x == 0");
            if (Mathf.Abs(currMove.x) < speedCutoff)
            {
                currMove.x = 0;
            } else
            {
                currMove.x /= speedLoss;
            }
        }

        if (moveVector.y == 0)
        {
            Debug.Log("Input y == 0");
            if (Mathf.Abs(currMove.y) < speedCutoff)
            {
                currMove.y = 0;
            }
            else
            {
                currMove.y /= speedLoss;
            }
        }

        if (Mathf.Abs(currMove.x) > maxSpeed) currMove.x = maxSpeed * curX;
        if (Mathf.Abs(currMove.y) > maxSpeed) currMove.y = maxSpeed * curY;

        //Debug.Log("X axis:" + currMove.x);
        //Debug.Log("Y axis:" + currMove.y);


        rigidbody2d.velocity = currMove;
    }

    public void move(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        Debug.Log("Moving");
    }
}
