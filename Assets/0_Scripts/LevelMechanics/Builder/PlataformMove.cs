using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMove : MonoBehaviour
{
    [SerializeField] private GameObject _myButton;

    [SerializeField] private string _myRightPlataform;
    [SerializeField] private string _myLeftPlataform;
    [SerializeField] private string _myUpPlataform;
    [SerializeField] private string _myDownPlataform;

    public void MoveRight()
    {
        transform.position += Vector3.right;

        RaycastHit hit;
        Physics.Raycast(transform.position, transform.right, out hit, 30);

        if(hit.collider.tag == _myRightPlataform)
        {
            hit.collider.transform.parent = transform;
        }
    }

    public void MoveLeft()
    {
        transform.position += Vector3.left;

        RaycastHit hit;
        Physics.Raycast(transform.position, transform.right * -1, out hit, 30);

        if (hit.collider.tag == _myLeftPlataform)
        {
            hit.collider.transform.parent = transform;
        }
    }

    public void MoveUp()
    {
        transform.position += Vector3.forward;

        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 30);

        if (hit.collider.tag == _myUpPlataform)
        {
            hit.collider.transform.parent = transform;
        }
    }

    public void MoveDown()
    {
        transform.position += Vector3.back;

        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward * -1, out hit, 30);

        if (hit.collider.tag == _myDownPlataform)
        {
            hit.collider.transform.parent = transform;
        }
    }
}
