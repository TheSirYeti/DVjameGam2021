using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedStateIdle : IState
{
    private Enemy enemy;
    private FiniteStateMachine fsm;
    private Transform target;

    public RangedStateIdle(Enemy enemy, FiniteStateMachine fsm, Transform target)
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
            Debug.Log("En Rango");
        }
    }

    public void OnExit()
    {
        
    }
}
