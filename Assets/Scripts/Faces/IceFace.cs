using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFace : IFace
{
    GameObject player;
    PlayerCombat pComb;
    public int ShieldAmount;
    Sprite icon;

    void Start()
    {
        player = GameObject.Find("Player");
        pComb = player.transform.GetComponent<PlayerCombat>();
        icon = (Sprite)Resources.Load("DefenceFaces/Ice");
    }

    public void Cast()
    {
        Start();
        pComb.AddShield(ShieldAmount);
    }

    public Sprite GetSprite()
    {
        return icon;
    }
}
