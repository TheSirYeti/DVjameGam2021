using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeIdleState : IState
{
    private Transform target;
    private Enemy enemy;
    private FiniteStateMachine fsm;

    public HordeIdleState(Enemy enemy, FiniteStateMachine fsm, Transform target)
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
        if (Vector3.Distance(target.position, enemy.transform.position) <= enemy.viewDistance)
        {
            fsm.ChangeState(MachineState.CHASE);
        }
    }

    public void OnExit()
    {
        
    }
}
