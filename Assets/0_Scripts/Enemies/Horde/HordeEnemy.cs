using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeEnemy : Enemy
{
    public FiniteStateMachine fsm;
    public float separationDistance;
    public float separationWeightValue;
    public float alignWeightValue;
    public float cohesionWeightValue;

    public Collider attackCollider;
    private void Start()
    {
        EnemyManager.instance.AddEnemy(this);
        fsm = new FiniteStateMachine();
        fsm.AddState(MachineState.CHASE, new HordeChaseState(this, fsm, target));
        fsm.AddState(MachineState.IDLE, new HordeIdleState(this, fsm, target));
        fsm.AddState(MachineState.ATTACK, new HordeAttackState(this, fsm));
        fsm.ChangeState(MachineState.CHASE);
    }

    private void Update()
    {  
        timer -= Time.fixedDeltaTime;
        if (timer <= Time.fixedDeltaTime)
        {
            timer = 0f;
            canAttack = true;
        }
        
        fsm.OnUpdate();
    }

    public override void Attack()
    {
        StartCoroutine(AttackTrigger());
    }

    IEnumerator AttackTrigger()
    {
        attackCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        attackCollider.enabled = false;
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
    
    Vector3 Cohesion()
    {
        Vector3 desired = new Vector3();
        int nearbyBoids = 0;

        foreach (var boid in EnemyManager.instance.GetEnemies())
        {
            if (boid != this && Vector3.Distance(boid.transform.position, transform.position) < viewDistance)
            {
                desired += boid.transform.position;
                nearbyBoids++;
            }
        }
        if (nearbyBoids == 0) return desired;
        desired /= nearbyBoids;
        desired = desired - transform.position;
        desired.Normalize();
        desired *= speed;

        Vector3 steering = desired - GetVelocity();
        steering = Vector3.ClampMagnitude(steering, maxForce);
        return steering;
    }

    Vector3 Align()
    {
        Vector3 desired = new Vector3();
        int nearbyBoids = 0;
        foreach (var boid in EnemyManager.instance.GetEnemies())
        {
            if (boid != this && Vector3.Distance(boid.transform.position, transform.position) < viewDistance)
            {
                desired += boid.GetVelocity();
                nearbyBoids++;
            }
        }
        if (nearbyBoids == 0) 
            return Vector3.zero;
        
        desired = desired / nearbyBoids;
        desired.Normalize();
        desired *= speed;

        Vector3 steering = Vector3.ClampMagnitude(desired - GetVelocity(), maxForce);

        return steering;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            EventManager.Trigger("SetPlayerHP", -1f);
        }
        
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("me pego");
            hp--;
            Destroy(other.gameObject);
        }

        if (hp == 0)
        {
            EnemyManager.instance.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }
}
