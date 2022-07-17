using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFace : IFace
{
    public int ShieldAmount = 1;
    Sprite icon;

    public void Init()
    {
        icon = (Sprite)Resources.Load("DefenceFaces/Ice");
    }

    public void Cast()
    {
        Debug.Log(GameManager.instace.playerControler);
        GameManager.instace.playerControler.pCombat.AddShield(ShieldAmount);
    }

    public Sprite GetSprite()
    {
        return icon;
    }
}
