using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ParentEnemyCombat : MonoBehaviour
{

    public int Health;

    abstract public void Damage(int amount);

    abstract public void Slow(int amount, int time);

    abstract public void Slide(int time);
}
