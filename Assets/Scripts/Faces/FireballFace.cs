using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireballFace : IFace
{
    GameObject pfBullet, player;
    Transform trans;
    Rigidbody2D rb;
    Vector3 mousePos;
    Camera cam;
    Sprite icon;

    //Values
    float distFromPlayer = 5f;

    public void Init()
    {
        player = GameObject.Find("Player");
        pfBullet = (GameObject)Resources.Load("Fireball");
        trans = player.GetComponent<Transform>();
        rb = player.GetComponent<Rigidbody2D>();
        cam = player.GetComponentInChildren<Camera>();
        icon = (Sprite)Resources.Load("AttackFaces/Fireball");
    }

    public void Cast()
    {
        Vector3 spellSpawn = new(trans.position.x, trans.position.y, 0);

        mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 0;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        LineRenderer lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        lineRenderer.sortingOrder = 1;
        lineRenderer.sortingLayerName = "Entity";

        lineRenderer.SetPosition(0, spellSpawn);
        lineRenderer.SetPosition(1, mousePos);

        mousePos.z = 0;
        mousePos -= spellSpawn;
        
        mousePos.Normalize();
        Vector3 dist = mousePos * distFromPlayer;
        spellSpawn += dist;

        GameObject bulletTransform = GameObject.Instantiate(pfBullet, spellSpawn, Quaternion.identity);
        bulletTransform.GetComponent<Fireball>().Setup(mousePos);
    }

    public Sprite GetSprite()
    {
        return icon;
    }
}
