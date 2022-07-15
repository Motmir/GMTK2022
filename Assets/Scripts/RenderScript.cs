using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderScript : MonoBehaviour
{
    //Values
    private SpriteRenderer sr;
    [SerializeField] private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        sr = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < player.position.y)
        {
            sr.sortingOrder = 0;
        } else
        {
            sr.sortingOrder = -2;
        }
    }
}
