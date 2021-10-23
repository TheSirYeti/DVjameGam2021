using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PopUpEnemy : Enemy
{
    private FiniteStateMachine fsm;
    public GameObject popUpPrefab;
    public List<Transform> spawnPoints;

    void Start()
    {
        fsm = new FiniteStateMachine();
        fsm.AddState(MachineState.IDLE, new PopUpStateIdle(this, fsm, target));
        fsm.AddState(MachineState.CHASE, new PopUpStateChase(this, fsm, target));
        fsm.ChangeState(MachineState.IDLE);
    }

    void Update()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= Time.fixedDeltaTime)
        {
            timer = 0f;
            canAttack = true;
        }
       fsm.OnUpdate(); 
    }
    
    public override void Attack()
    {
        var popUp = Instantiate(popUpPrefab);
        popUp.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;

        timer = attackCooldown + Time.deltaTime;
    }
    
    
}
