using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFace : MonoBehaviour
{
    GameObject player;
    PlayerCombat pComb;

    private void Start()
    {
        player = GameObject.Find("Player");
        pComb = player.transform.GetComponent<PlayerCombat>();
    }
}
