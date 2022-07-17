using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFace : IFace
{
    GameObject player;
    PlayerCombat pComb;
    public int ShieldAmount;
    Sprite icon;

    public void Init()
    {
        player = GameObject.Find("Player");
        pComb = player.transform.GetComponent<PlayerCombat>();
        icon = (Sprite)Resources.Load("DefenceFaces/Ice");
    }

    public void Cast()
    {
        pComb.AddShield(ShieldAmount);
    }

    public Sprite GetSprite()
    {
        return icon;
    }
}
