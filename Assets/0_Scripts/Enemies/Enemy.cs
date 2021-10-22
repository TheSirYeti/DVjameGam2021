using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IEntity
{
    [SerializeField] float hp;
    public float maxForce;
    public float speed;
    private Vector3 _velocity;
    public float viewDistance;

    private void Start()
    {
        EnemyManager.instance.AddEnemy(this);
    }

    public abstract void TakeDamage();

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
