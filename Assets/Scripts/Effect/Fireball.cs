using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : ParentBullet
{
    public override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyCombat>() as EnemyCombat != null)
        {
            EnemyCombat hit = collider.GetComponent<EnemyCombat>();
            hit.Damage(damage);
        }
        Destroy(gameObject);
    }

    public override void Setup(Vector3 Dir)
    {
        damage = 2;
        rb = transform.GetComponent<Rigidbody2D>();

        float rotation = Mathf.Rad2Deg * Mathf.Atan2(Dir.y, Dir.x);
        gameObject.transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);

        rb.velocity = Dir * speed;
    }
}

