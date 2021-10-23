using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrojanStateIdle : IState
{
    private Enemy enemy;
    private FiniteStateMachine fsm;
    private Transform target;

    public TrojanStateIdle(Enemy enemy, FiniteStateMachine fsm, Transform target)
    {
        this.enemy = enemy;
        this.fsm = fsm;
        this.target = target;
    }

    public void OnStart()
    {
        
    }

    public void OnUpdate()
    {
        if (Vector3.Distance(enemy.transform.position, target.position) <= enemy.viewDistance)
        {
            fsm.ChangeState(MachineState.CHASE);
        }
    }

    public void OnExit()
    {
        
    }
}
