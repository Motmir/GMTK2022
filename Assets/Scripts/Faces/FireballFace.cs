using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireballFace : IFace
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
        pfBullet = (GameObject)Resources.Load("Fireball");
        trans = player.GetComponent<Transform>();
        rb = player.GetComponent<Rigidbody2D>();
        cam = player.GetComponentInChildren<Camera>();
        mouse = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        icon = (Sprite)Resources.Load("AttackFaces/Fireball");
    }

    public void Cast()
    {
        Vector3 spellSpawn = new(trans.position.x, trans.position.y, 0);
        mouse.z = 0;
        mouse -= spellSpawn;
        mouse.Normalize();
        Vector3 dist = mouse * distFromPlayer;
        spellSpawn += dist;

        GameObject bulletTransform = GameObject.Instantiate(pfBullet, spellSpawn, Quaternion.identity);
        bulletTransform.GetComponent<Fireball>().Setup(mouse, 0);
    }

    public Sprite GetSprite()
    {
        return icon;
    }
}
