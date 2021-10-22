using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeChaseState : IState
{
    public Enemy enemy;
    public Transform target;
    public void OnStart()
    {
        
    }

    public HordeChaseState(Enemy enemy, Transform target)
    {
        this.enemy = enemy;
        this.target = target;
    }
    
    public void OnUpdate()
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

    public void OnExit()
    {
        
    }
}
