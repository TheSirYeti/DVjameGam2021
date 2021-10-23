using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpStateChase : IState
{
    private Enemy enemy;
    private FiniteStateMachine fsm;
    private Transform target;
    public void OnStart()
    {
        throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
        if (Vector3.Distance(enemy.transform.position, target.position) <= enemy.viewDistance + 3f)
        {
            enemy.CanAttack();
        } else fsm.ChangeState(MachineState.IDLE);
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }
}
