using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderMove : MonoBehaviour
{
    private bool _isMoving = false;
    [SerializeField] private CameraBeheivor mainCamera;
    [SerializeField] private PlataformMove _myPlataformMovement;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Vector3 _AddVectorCameraPosition;


    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _myPlataform;
    [SerializeField] private GameObject _camera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && _isMoving == true)
        {
            _myPlataformMovement.MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.A) && _isMoving == true)
        {
            _myPlataformMovement.MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.S) && _isMoving == true)
        {
            _myPlataformMovement.MoveDown();
        }
        else if (Input.GetKeyDown(KeyCode.W) && _isMoving == true)
        {
            _myPlataformMovement.MoveUp();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && _isMoving == false)
        {
            _player.transform.parent = _myPlataform.transform;
            transform.parent = _myPlataform.transform;
            _camera.transform.parent = _myPlataform.transform;
            Debug.Log("Accione");
            _isMoving = true;
            mainCamera.ActiveBuildingMode(_AddVectorCameraPosition);
            _playerMovement.ChangeMovementState(false);
        }

        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Escape) && _isMoving == true)
        {
            _player.transform.parent = null;
            transform.parent = null;
            _camera.transform.parent = null;
            Debug.Log("AccioneApagado");
            _isMoving = false;
            mainCamera.DesactivateBuildingMode(_AddVectorCameraPosition);
            _playerMovement.ChangeMovementState(true);
        }
    }
}
