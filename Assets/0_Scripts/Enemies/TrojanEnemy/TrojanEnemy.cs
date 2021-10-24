using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TrojanEnemy : Enemy
{
    private FiniteStateMachine fsm;
    public GameObject prefab;
    public List<Transform> spawnPoints = new List<Transform>();

    private void Start()
    {
        EnemyManager.instance.AddEnemy(this);
        fsm = new FiniteStateMachine();
        fsm.AddState(MachineState.IDLE, new TrojanStateIdle(this, fsm, target));
        fsm.AddState(MachineState.CHASE, new TrojanStateChase(this, fsm, target));
        fsm.AddState(MachineState.ATTACK, new TrojanStateAttack(this, fsm, target));
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
        canAttack = false;
        foreach (Transform t in spawnPoints)
        {
            var minion = Instantiate(prefab);
            minion.transform.position = t.position;
            minion.GetComponent<Enemy>().target = target;
            minion.GetComponent<Enemy>().viewDistance = 99f;
        }

        timer = attackCooldown + Time.fixedDeltaTime;
    }
}
