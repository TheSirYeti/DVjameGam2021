using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrojanStateAttack : IState
{
    private Enemy enemy;
    private FiniteStateMachine fsm;
    private Transform target;

    public TrojanStateAttack(Enemy enemy, FiniteStateMachine fsm, Transform target)
    {
        this.enemy = enemy;
        this.fsm = fsm;
        this.target = target;
    }

    public void OnStart()
    {
        enemy.Attack();
        fsm.ChangeState(MachineState.IDLE);
    }

    public void OnUpdate()
    {
        
    }

    public void OnExit()
    {
        
    }
}
