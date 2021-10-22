using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBeheivor : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private float VclampUp;
    [SerializeField] private float VclampDown;

    [SerializeField] private float HclampDer;
    [SerializeField] private float HclampIzq;

    private Vector3 movement;

    void Update()
    {
        movement = new Vector3(_player.position.x, transform.position.y, _player.position.z - 5.5f);

       
        if(_player.position.x > HclampDer)
        {
            movement.x = HclampDer;
            transform.position = movement;
        }
        else if(_player.position.x < HclampIzq)
        {
            movement.x = HclampIzq;
            transform.position = movement;
        }

        if (_player.position.z - 5.5f > VclampUp)
        {
            movement.z = VclampUp;
            transform.position = movement;
        }
        else if (_player.position.z - 5.5f < VclampDown)
        {
            movement.z = VclampDown;
            transform.position = movement;
        }

        if (_player.position.x < HclampDer && _player.position.x > HclampIzq)
        {
            transform.position = movement;
        }

    }
}
