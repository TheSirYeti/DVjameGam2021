using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedStateChase : IState
{
    private Enemy enemy;
    private FiniteStateMachine fsm;
    private Transform target;

    public RangedStateChase(Enemy enemy, FiniteStateMachine fsm, Transform target)
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
        if (Vector3.Distance(enemy.transform.position, target.position) <= enemy.viewDistance + 3f)
        {
            enemy.CanAttack();
            Debug.Log("Ataco");
        }
        else fsm.ChangeState(MachineState.IDLE);
    }

    public void OnExit()
    {
        
    }
}
