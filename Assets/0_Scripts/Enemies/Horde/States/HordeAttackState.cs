using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeAttackState : IState
{
    public FiniteStateMachine fsm;
    public Enemy enemy;

    public HordeAttackState(Enemy enemy, FiniteStateMachine fsm)
    {
        this.enemy = enemy;
        this.fsm = fsm;
    }
    
    public void OnStart()
    {
        //Do Attack
        enemy.GetComponent<HordeEnemy>().Attack();
        fsm.ChangeState(MachineState.IDLE);
    }

    public void OnUpdate()
    {
        //Do Attack
    }

    public void OnExit()
    {
        //Do Attack
    }
}
