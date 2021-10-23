using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpStateIdle : IState
{
    private FiniteStateMachine fsm;
    private Enemy enemy;
    private Transform target;

    public PopUpStateIdle(Enemy enemy, FiniteStateMachine fsm, Transform target)
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
        if (Vector3.Distance(enemy.transform.position, target.transform.position) <= enemy.viewDistance)
        {
            fsm.ChangeState(MachineState.CHASE);
        }
    }

    public void OnExit()
    {
        
    }
}
