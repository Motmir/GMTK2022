using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyFace : IFace
{

    public void Init ()
    {

    }
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
