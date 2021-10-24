using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBeheivor : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 movement;

    private bool _isBuilding = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (_isBuilding == false)
            Follow();
    }

    private void Follow()
    {
        movement = new Vector3(_player.position.x, transform.position.y, _player.position.z - 7f);
        transform.position = movement;
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
