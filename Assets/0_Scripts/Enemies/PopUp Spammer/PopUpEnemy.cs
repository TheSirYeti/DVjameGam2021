using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PopUpEnemy : Enemy
{
    private FiniteStateMachine fsm;
    public GameObject popUpPrefab;
    public List<Transform> spawnPoints;


    void Start()
    {
        fsm = new FiniteStateMachine();
    }
    
    
    
    public override void Attack()
    {
        var popUp = Instantiate(popUpPrefab);
        popUp.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
    }
    
    
}
