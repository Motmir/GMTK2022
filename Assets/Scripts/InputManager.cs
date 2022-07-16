using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instace = null;

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
        else
        {
            DestroyImmediate(transform.gameObject);
        }

    }
}
