using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFace : IFace
{
    public int HealAmount = 2;
    Sprite icon;

    public void Init()
    {
        icon = (Sprite)Resources.Load("UtilityFaces/Heal");
    }

    public void Cast()
    {
        GameManager.instace.playerControler.pCombat.AddHealth(HealAmount);
    }

    public Sprite GetSprite()
    {
        return icon;
    }
}
