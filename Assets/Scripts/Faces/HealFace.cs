using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFace : IFace
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
        pComb.AddHealth(ShieldAmount);
    }

    public Sprite GetSprite()
    {
        throw new System.NotImplementedException();
    }
}
