using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFace
{

    abstract void Init();

    abstract void Cast();

    Sprite GetSprite();

}
