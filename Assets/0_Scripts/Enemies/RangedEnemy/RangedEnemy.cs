using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public GameObject bulletPrefab;
    private FiniteStateMachine fsm;

    void Start()
    {
        EnemyManager.instance.AddEnemy(this);
        fsm = new FiniteStateMachine();
        fsm.AddState(MachineState.IDLE, new RangedStateIdle(this, fsm, target));
        fsm.AddState(MachineState.CHASE, new RangedStateChase(this, fsm, target));
        fsm.ChangeState(MachineState.IDLE);
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
        Debug.Log("DISPARO");
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.transform.forward = new Vector3(target.transform.position.x, 0, target.transform.position.z);
        bullet.transform.LookAt(target);
    }
}
