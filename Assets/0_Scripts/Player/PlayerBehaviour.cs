using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float hp;

    private void Start()
    {
        EventManager.Subscribe("SetPlayerHP", SetHP);
    }

    void SetHP(object[] parameters)
    {
        hp += (float)parameters[0];
        Debug.Log("auch");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemyAttack")
        {
            EventManager.Trigger("SetPlayerHP", -1f);
        }
    }
}
