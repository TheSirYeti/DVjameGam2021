using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Fisicas
    [SerializeField] private Rigidbody _rb = null;

    //Movement Inputs
    [SerializeField] private float _speed = 0;
    private float _horizontal, _vertical;
    private float _movementMagnitud;
    private Vector3 _movementVector;

    //VectoresMouse
    Vector2 mousePos = new Vector2();
    Vector3 point = new Vector3();

    private bool canMove = true;
    void Update()
    {
        if (canMove)
        {
            Movement();
            Rotation();
        }
    }

    private void Movement()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _movementVector.x = _horizontal;
        _movementVector.z = _vertical;

        _movementMagnitud = _movementVector.magnitude;

        if (_movementMagnitud > 1)
        {
            _rb.MovePosition(transform.position + _movementVector.normalized * (_speed * Time.deltaTime));
            _movementMagnitud = 1;
        }
        else
            _rb.MovePosition(transform.position + _movementVector * (_speed * Time.deltaTime));
    }

    private void Rotation()
    {
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;

        point = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        point.y = 1;

        transform.LookAt(point);
    }

    public void ChangeMovementState(bool movementState)
    {
        canMove = movementState;
    }
}
