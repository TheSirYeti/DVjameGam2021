using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeChaseState : IState
{
    private Enemy enemy;
    private Transform target;
    private FiniteStateMachine fsm;
    public void OnStart()
    {
        
    }

    public HordeChaseState(Enemy enemy, FiniteStateMachine fsm, Transform target)
    {
        this.enemy = enemy;
        this.target = target;
        this.fsm = fsm;
    }
    
    public void OnUpdate()
    {
        enemy.rb.velocity = Vector3.zero;
        if (Vector3.Distance(enemy.transform.position, target.position) <= enemy.viewDistance + 3f)
        {
            Vector3 desired = target.transform.position - enemy.transform.position;
            desired.Normalize();
            desired *= enemy.speed;

            Vector3 steering = desired - enemy.GetVelocity();
            steering = Vector3.ClampMagnitude(steering, enemy.maxForce);
            
            enemy.ApplyForce(steering);
            enemy.transform.position += enemy.GetVelocity() * Time.deltaTime;
            enemy.transform.forward = enemy.GetVelocity().normalized;
        }
        else
        {
            fsm.ChangeState(MachineState.IDLE);
        }
    }

    public void OnExit()
    {
        
    }
}
