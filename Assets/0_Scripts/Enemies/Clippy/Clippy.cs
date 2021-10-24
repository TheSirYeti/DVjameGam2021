using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Clippy : MonoBehaviour
{
    public List<GameObject> clippyPoints;
    public float timeToAttack;
    private bool canAttack = true;
    public float timeAlive;

    private void Start()
    {
        StartCoroutine(AttackCycle());
    }

    IEnumerator AttackCycle()
    {
        while (canAttack)
        {
            StartCoroutine(SpawnAttack());
            yield return new WaitForSeconds(timeToAttack);
        }
    }

    IEnumerator SpawnAttack()
    {
        int rand = Random.Range(0, clippyPoints.Count);
        clippyPoints[rand].SetActive(true);
        yield return new WaitForSeconds(timeAlive);
        clippyPoints[rand].SetActive(false);
    }
}
