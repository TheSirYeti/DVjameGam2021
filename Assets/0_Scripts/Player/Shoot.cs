using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnPoint;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var IBullet = Instantiate(_bullet, _spawnPoint.position, _spawnPoint.rotation);
            Destroy(IBullet, 3f);
        }
    }
}
