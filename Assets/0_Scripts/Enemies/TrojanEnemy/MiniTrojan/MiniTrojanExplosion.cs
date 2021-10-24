using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniTrojanExplosion : MonoBehaviour
{
    public float explosionTime;

    private void Start()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(explosionTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //menos vida
        }
    }
}
