using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFace : IFace
{
    GameObject player;
    PlayerCombat pComb;
    public int ShieldAmount;

    void Start()
    {
        player = GameObject.Find("Player");
        pComb = player.transform.GetComponent<PlayerCombat>();
    }

    public void Cast()
    {
        Start();
        pComb.AddShield(ShieldAmount);
    }

    public Sprite GetSprite()
    {
        throw new System.NotImplementedException();
    }
}
