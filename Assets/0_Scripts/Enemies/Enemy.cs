using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float hp;
    public float maxForce;
    public float speed;
    private Vector3 _velocity;
    public float viewDistance;
    public Rigidbody rb;
    public Transform target;
    
    public float attackCooldown;

    public float timer;
    public bool canAttack = true;

    private void Start()
    {
        EnemyManager.instance.AddEnemy(this);
    }

    private void Update()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= Time.fixedDeltaTime)
        {
            timer = 0f;
            canAttack = true;
        }
    }

    public abstract void Attack();

    public void CanAttack()
    {
        if (canAttack)
        {
            Debug.Log("ataque");
            Attack();
            timer = attackCooldown + Time.fixedDeltaTime;
            canAttack = false;
        }
    }
    
    public void ApplyForce(Vector3 force)
    {
        _velocity += force;
        _velocity.y = 0;
    }

    public Vector3 GetVelocity()
    {
        return _velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
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
