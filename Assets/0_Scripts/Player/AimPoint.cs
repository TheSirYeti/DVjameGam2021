using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPoint : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _mouseX;
    private float _mouseY;

    [SerializeField] private float _minClampY, _minClampX, _maxClampY, _maxClampX;

    private void Start()
    {
        /*Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;*/
    }
    void Update()
    {
        /*_mouseX += Input.GetAxis("Mouse X");
        _mouseY += Input.GetAxis("Mouse Y");

        if (_mouseY > _maxClampY)
            _mouseY = _maxClampY;
        else if (_mouseY < _minClampY)
            _mouseY = _minClampY;

        if (_mouseX > _maxClampX)
            _mouseX = _maxClampX;
        else if (_mouseX < _minClampX)
            _mouseX = _minClampX;


        transform.position = new Vector3(_mouseX, 1, _mouseY) * _speed;*/


    }
}
