using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class MiniTrojan : Enemy
{
    public float timeToExplode;
    public GameObject explosionPrefab;
    public bool canMove;
    public Material originalMaterial;
    public Material tickMaterial;
    void Start()
    {
        EnemyManager.instance.AddEnemy(this);
        originalMaterial = GetComponent<MeshRenderer>().material;
        StartCoroutine(MakeExplosion());
    }

    void Update()
    {
        if (canMove)
        {
            Vector3 desired = target.transform.position - transform.position;
            desired.Normalize();
            desired *= speed;

            Vector3 steering = desired - GetVelocity();
            steering = Vector3.ClampMagnitude(steering, maxForce);
            
            ApplyForce(steering);
            transform.position += GetVelocity() * Time.deltaTime;
            transform.forward = GetVelocity().normalized;
        }
    }
    
    public override void Attack()
    {
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        canMove = false;
        Destroy(gameObject);
    }

    public IEnumerator MakeExplosion()
    {
        while (canMove)
        {
            GetComponent<MeshRenderer>().material = tickMaterial;
            timeToExplode -= Time.fixedDeltaTime;
            yield return new WaitForSeconds(timeToExplode / 2);
            GetComponent<MeshRenderer>().material = originalMaterial;
            yield return new WaitForSeconds(timeToExplode / 2);
            if (timeToExplode <= 0.05f)
            {
                Attack();
                StopCoroutine(MakeExplosion());
            }
        }
    }
}
