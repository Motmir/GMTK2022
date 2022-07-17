using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grease : ParentBullet
{

    static List<GameObject> targetsHit = new List<GameObject>();
    public override void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject targetHit = collider.GetComponent<GameObject>();
        if (collider.GetComponent<EnemyCombat>() as EnemyCombat != null && targetsHit.IndexOf(collider.GetComponent<GameObject>()) == -1)
        {
            EnemyCombat hit = collider.GetComponent<EnemyCombat>();
            targetsHit.Add(targetHit);
            hit.Slide(duration);
        }
    }

    public override void Setup(Vector3 Dir, int id)
    {
        damage = 0;
        duration = 2;
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(2);
        targetsHit = new List<GameObject>();
        Destroy(gameObject);
    }
}
