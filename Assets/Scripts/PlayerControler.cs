using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    //Values
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private Vector2 moveVector;
    private Vector3 currMove;
    
    //Attributes
    public float speed = 2;
    public float maxSpeed = 9.25f;
    public float speedLoss = 2;
    public float speedCutoff = 3;
    public float turnModifier = 6;

    //Booleans
    int xMod;
    int yMod;


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
        PlayerMove();
    }

    private void PlayerMove() 
    {
        if (moveVector.x > 0) //Check if accelerating right or left
        {
            xMod = 1;
        } else if (moveVector.x < 0)
        {
            xMod = -1;
        }

        if (moveVector.y > 0) //Check if accelerating up or down
        {
            yMod = 1;
        } else if (moveVector.y < 0)
        {
            yMod = -1;
        }

        int curX;
        int curY;

        if (currMove.x >= 0) //Check if move right or left
        {
            curX = 1;
        }
        else
        {
            curX = -1;
        }

        if (currMove.y >= 0) //Check if move up or down
        {
            curY = 1;
        }
        else
        {
            curY = -1;
        }


        float speedX = Mathf.Abs(moveVector.x) * speed;
        float speedY = Mathf.Abs(moveVector.y) * speed;

        if (curX != xMod)
        {
            speedX *= turnModifier;
        }

        if (curY != yMod)
        {
            speedY *= turnModifier;
        }

        Vector3 movement = new Vector3(
            speedX * xMod, //x
            speedY * yMod, //y
            0 //z
            );

        currMove += movement;

        

        if (moveVector.x == 0)
        {
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


        rigidbody2d.velocity = currMove;
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!UIManager.paused) return;
        moveVector = context.ReadValue<Vector2>();    
    }

    public void UseEffect(InputAction.CallbackContext context)
    {
        if (!UIManager.paused) return;
        if (context.started)
        {
            Debug.Log(context.control.name);
            if (context.control.name == "leftButton")
            {
                IFace face = new VineFace();
                face.Cast();
            }
            if (context.control.name == "rightButton")
            {
                IFace face = new FireballFace();
                face.Cast();
            }
        }
    }

}
