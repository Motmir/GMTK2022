using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParentBullet: MonoBehaviour
{
    [System.NonSerialized] protected Rigidbody2D rb;
    [System.NonSerialized] protected float speed = 15;

    public abstract void Setup(Vector3 Dir);

    public abstract void OnTriggerEnter2D(Collider2D collider);
}

