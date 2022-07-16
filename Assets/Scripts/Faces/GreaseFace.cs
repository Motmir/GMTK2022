using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GreaseFace : IFace
{
    GameObject pfBullet, player;
    Camera cam;
    Vector3 mouse;
    Sprite icon;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pfBullet = (GameObject)Resources.Load("Grease");
        cam = player.GetComponentInChildren<Camera>();
        mouse = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        icon = (Sprite)Resources.Load("UtilityFaces/Grease");
    }

    public void Cast()
    {
        Start();

        Vector3 spellSpawn = new(mouse.x, mouse.y, 0);

        GameObject bulletTransform = GameObject.Instantiate(pfBullet, spellSpawn, Quaternion.identity);
        bulletTransform.GetComponent<Grease>().Setup(mouse);
    }

    public Sprite GetSprite()
    {
        return icon;
    }
}
