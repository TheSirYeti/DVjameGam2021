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

    private bool _isBuilding = false;

    void Update()
    {
        if (_isBuilding == false)
            Follow();

    }

    private void Follow()
    {
        movement = new Vector3(_player.position.x, transform.position.y, _player.position.z - 7f);

        if (_player.position.x > HclampDer)
        {
            movement.x = HclampDer;
            transform.position = movement;
        }
        else if (_player.position.x < HclampIzq)
        {
            movement.x = HclampIzq;
            transform.position = movement;
        }

        if (_player.position.z - 7f > VclampUp)
        {
            movement.z = VclampUp;
            transform.position = movement;
        }
        else if (_player.position.z - 7f < VclampDown)
        {
            movement.z = VclampDown;
            transform.position = movement;
        }

        if (_player.position.x < HclampDer && _player.position.x > HclampIzq)
        {
            transform.position = movement;
        }
    }

    public void ActiveBuildingMode(Vector3 newCameraPosition)
    {
        _isBuilding = true;
        transform.position += newCameraPosition;
    }

    public void DesactivateBuildingMode(Vector3 newCameraPosition)
    {
        _isBuilding = false;
        transform.position -= newCameraPosition;
    }
}
