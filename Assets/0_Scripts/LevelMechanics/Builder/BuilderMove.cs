using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderMove : MonoBehaviour
{
    private bool _isMoving = false;
    [SerializeField] private CameraBeheivor mainCamera;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Vector3 _AddVectorCameraPosition;

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && _isMoving == false)
        {
            Debug.Log("Accione");
            _isMoving = true;
            mainCamera.ActiveBuildingMode(_AddVectorCameraPosition);
            player.ChangeMovementState(false);
        }

        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Escape) && _isMoving == true)
        {
            Debug.Log("AccioneApagado");
            _isMoving = false;
            mainCamera.DesactivateBuildingMode(_AddVectorCameraPosition);
            player.ChangeMovementState(true);
        }
    }
}
