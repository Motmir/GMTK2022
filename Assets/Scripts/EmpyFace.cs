using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpyFace : IFace
{

    Sprite icon = Resources.Load<Sprite>("ShittyPlaceHolderIcon");

    public void Cast()
    {
        //nothing
    }

    public Sprite GetSprite()
    {
        return icon;
    }

}
