using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFace : IFace
{
    GameObject player;
    PlayerCombat pComb;
    public int ShieldAmount;
    Sprite icon;

    public void Init()
    {
        player = GameObject.Find("Player");
        pComb = GameManager.instace.playerControler.pCombat;
        icon = (Sprite)Resources.Load("UtilityFaces/Heal");
    }

    public void Cast()
    {
        pComb.AddHealth(ShieldAmount);
    }

    public Sprite GetSprite()
    {
        return icon;
    }
}
