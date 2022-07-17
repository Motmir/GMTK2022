using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupFace : IFace
{
    GameObject player;
    PlayerCombat pComb;
    public int ShieldAmount;
    Sprite icon;


    public void Init()
    {
        Debug.Log("INIT");
        player = GameObject.Find("Player");
        pComb = player.GetComponent<PlayerCombat>();
        icon = (Sprite)Resources.Load("UtilityFaces/SpeedUp");
    }

    public void Cast()
    {
        Debug.Log(player.GetComponent<PlayerCombat>());
        pComb.SpeedUp(5);
    }

    public Sprite GetSprite()
    {
        return icon;
    }
}
