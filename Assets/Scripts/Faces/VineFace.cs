using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VineFace : IFace
{
    GameObject pfBullet, player;
    Camera cam;
    Vector3 mouse;
    Sprite icon;

    // Start is called before the first frame update
    public void Init()
    {
        player = GameObject.Find("Player");
        pfBullet = (GameObject)Resources.Load("Vines");
        cam = player.GetComponentInChildren<Camera>();
        mouse = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        icon = (Sprite)Resources.Load("UtilityFaces/Vine");
    }

    public void Cast()
    {
        Vector3 spellSpawn = new(mouse.x, mouse.y, 0);

        GameObject bulletTransform = GameObject.Instantiate(pfBullet, spellSpawn, Quaternion.identity);
        bulletTransform.GetComponent<Vines>().Setup(mouse);
    }

    public Sprite GetSprite()
    {
        return icon;
    }
}
