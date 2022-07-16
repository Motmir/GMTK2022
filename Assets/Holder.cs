using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ParentFace : MonoBehaviour
{
    Sprite icon;
    // Start is called before the first frame update
    abstract public void OnTriggerEnter2D(Collider2D collider);

    abstract public void Setup(Vector3 Dir);
}
