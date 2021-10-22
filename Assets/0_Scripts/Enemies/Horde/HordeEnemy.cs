using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeEnemy : Enemy
{
    public FiniteStateMachine fsm;
    public Transform target;
    public float separationDistance;
    public float separationWeightValue;
    public float alignWeightValue;
    public float cohesionWeightValue;
    
    private void Start()
    {
        EnemyManager.instance.AddEnemy(this);
        
        fsm = new FiniteStateMachine();
        fsm.AddState(MachineState.CHASE, new HordeChaseState(this, fsm, target));
        fsm.AddState(MachineState.IDLE, new HordeIdleState(this, fsm, target));
        fsm.ChangeState(MachineState.CHASE);
    }

    private void Update()
    {
        fsm.OnUpdate();
        ApplyForce(Separation() * separationWeightValue);
    }

    public override void TakeDamage()
    {
        
    }
    
    public Vector3 Separation()
    {
        Vector3 desired = new Vector3();
        int nearbyBoids = 0;

        foreach (var item in EnemyManager.instance.GetEnemies())
        {
            Vector3 dist = item.transform.position - transform.position;

            if (item != this && dist.magnitude < separationDistance)
            {
                desired.x += dist.x;
                desired.z += dist.z;
                nearbyBoids++;
            }
        }
        if (nearbyBoids == 0) return desired;
        desired /= nearbyBoids;
        desired.Normalize();
        desired *= speed;
        desired = -desired;

        Vector3 steering = desired - GetVelocity();
        steering = Vector3.ClampMagnitude(steering, maxForce);
        return steering;
    }
}
