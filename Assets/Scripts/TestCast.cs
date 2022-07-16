using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestCast : MonoBehaviour
{
    public void UseEffect(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        IFace face = new Fireball();
        face.Cast();
    }
}
