using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFace : IFace
{
    GameObject player;
    PlayerCombat pComb;
    public int ShieldAmount;
    Sprite icon;

    void Start()
    {
        player = GameObject.Find("Player");
        pComb = player.transform.GetComponent<PlayerCombat>();
        icon = (Sprite)Resources.Load("UtilityFaces/Heal");
    }

    public void Cast()
    {
        Start();
        pComb.AddHealth(ShieldAmount);
    }

    public Sprite GetSprite()
    {
        return icon;
    }
}
