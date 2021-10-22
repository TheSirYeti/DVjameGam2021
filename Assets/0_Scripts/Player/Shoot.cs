using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnPoint;
    private float _timer;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _timer += 1 * Time.deltaTime;
            if (_timer > 0.2f)
            {
                var IBullet = Instantiate(_bullet, _spawnPoint.position, _spawnPoint.rotation);
                Destroy(IBullet, 3f);
                _timer = 0;
            }
        }
    }
}
