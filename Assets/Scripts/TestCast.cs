using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestCast : MonoBehaviour
{
    public void UseEffect(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (context.control.name == "leftButton")
            {
                IFace face = new VineFace();
                face.Cast();
            }
            if (context.control.name == "rightButton")
            {
                IFace face = new FireballFace();
                face.Cast();
            }
        }
        
        
    }
}
