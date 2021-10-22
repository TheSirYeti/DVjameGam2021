using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBeheivor : MonoBehaviour
{
    [SerializeField] private Transform _player;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.position.x, transform.position.y, _player.position.z - 5.5f);
    }
}
