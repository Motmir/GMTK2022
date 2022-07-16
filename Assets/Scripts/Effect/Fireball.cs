using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : ParentBullet
{
    public override void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.GetComponent<EnemyCombat>() as EnemyCombat != null);
        if (collider.GetComponent<EnemyCombat>() as EnemyCombat != null)
        {
            collider.GetComponent<EnemyCombat>().Damage(damage);
        }
        Destroy(gameObject);
    }

    public override void Setup(Vector3 Dir)
    {
        damage = 2;
        rb = transform.GetComponent<Rigidbody2D>();

        float rotation = Mathf.Rad2Deg * Mathf.Atan2(Dir.y, Dir.x);
        gameObject.transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);

        Debug.Log("Dir: " + Dir + "Norm: " + Dir.normalized);
        rb.velocity = Dir * speed;
    }
}

