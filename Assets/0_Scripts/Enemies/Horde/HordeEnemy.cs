using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeEnemy : Enemy
{
    public FiniteStateMachine fsm;
    public Transform target;
    
    private void Start()
    {
        fsm = new FiniteStateMachine();
        fsm.AddState(MachineState.CHASE, new HordeChaseState(this, target));
        fsm.ChangeState(MachineState.CHASE);
    }

    private void Update()
    {
        fsm.OnUpdate();
    }

    public override void TakeDamage()
    {
        
    }
}
