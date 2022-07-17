using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShotgunFace : IFace
{

    GameObject pfBullet, player;
    Transform trans;
    Rigidbody2D rb;
    Vector3 mouse;
    Camera cam;
    Sprite icon;

    //Values
    float distFromPlayer = 0f;

    public void Init()
    {
        player = GameObject.Find("Player");
        pfBullet = (GameObject)Resources.Load("Pellet");
        trans = player.GetComponent<Transform>();
        rb = player.GetComponent<Rigidbody2D>();
        cam = player.GetComponentInChildren<Camera>();
        mouse = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        icon = (Sprite)Resources.Load("AttackFaces/Shotgun");
    }

    public void Cast()
    {
        Vector3 spellSpawn = new(trans.position.x, trans.position.y, 0);
        mouse.z = 0;
        mouse -= spellSpawn;
        mouse.Normalize();
        Vector3 dist = mouse * distFromPlayer;
        spellSpawn += dist;
        int id = -1;

        Vector3 mouse2 = new Vector3(mouse.x * Mathf.Cos(0.08f) - mouse.y * Mathf.Sin(0.08f), mouse.x * Mathf.Sin(0.08f) + mouse.y * Mathf.Cos(0.08f), 0);
        GameObject bulletTransform = GameObject.Instantiate(pfBullet, spellSpawn, Quaternion.identity);
        bulletTransform.GetComponent<Pellet>().Setup(mouse2, 0);
        bulletTransform = GameObject.Instantiate(pfBullet, spellSpawn, Quaternion.identity);
        bulletTransform.GetComponent<Pellet>().Setup(mouse, 0);
        mouse2 = new Vector3(mouse.x * Mathf.Cos(-0.08f) - mouse.y * Mathf.Sin(-0.08f), mouse.x * Mathf.Sin(-0.08f) + mouse.y * Mathf.Cos(-0.08f), 0);
        bulletTransform = GameObject.Instantiate(pfBullet, spellSpawn, Quaternion.identity);
        bulletTransform.GetComponent<Pellet>().Setup(mouse2, 0);

        /*while (id <= 1)
        {
            Debug.Log(id);
            if (id != 0)
            {
                mouse = new Vector3(mouse.x * Mathf.Cos(0.08f * id) - mouse.y * Mathf.Sin(0.08f * id), mouse.x * Mathf.Sin(0.08f * id) + mouse.y * Mathf.Cos(0.08f * id), 0);
            }
            bulletTransform = GameObject.Instantiate(pfBullet, spellSpawn, Quaternion.identity);
            bulletTransform.GetComponent<Pellet>().Setup(mouse, 0);
            id++;
        }*/
        
    }
     
    public Sprite GetSprite()
    {
        return icon;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
