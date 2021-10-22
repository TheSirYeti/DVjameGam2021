using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeheivor : MonoBehaviour
{
    [SerializeField] private LayerMask _colliderMask;
    [SerializeField] private float _speed;
    
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == _colliderMask)
        {
            Destroy(gameObject);
        }
    }
}
