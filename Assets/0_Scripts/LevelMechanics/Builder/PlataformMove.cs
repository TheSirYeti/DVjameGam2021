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

    [SerializeField] private Transform _upRight;
    [SerializeField] private Transform _upLeft;
    [SerializeField] private Transform _downRight;
    [SerializeField] private Transform _downLeft;

    public void MoveRight()
    {
        transform.position += Vector3.right;

        RaycastHit hitUp;
        Physics.Raycast(_upRight.position, transform.right, out hitUp, 0.5f);

        RaycastHit hitDown;
        Physics.Raycast(_downRight.position, transform.right, out hitDown, 0.5f);

        if (hitUp.collider == hitDown.collider && hitUp.collider.tag == _myRightPlataform)
        {
            GameObject other = hitUp.collider.gameObject;

            while (other.transform.parent != null)
            {
                other = other.transform.parent.gameObject;
            }

            other.transform.parent = transform;
            other.gameObject.GetComponent<PlataformMove>().DestroyMyButton();
        }
    }

    public void MoveLeft()
    {
        transform.position += Vector3.left;

        RaycastHit hitUp;
        Physics.Raycast(_upLeft.position, transform.right * -1, out hitUp, 0.5f);

        RaycastHit hitDown;
        Physics.Raycast(_downLeft.position, transform.right * -1, out hitDown, 0.5f);

        if (hitUp.collider == hitDown.collider && hitUp.collider.tag == _myLeftPlataform)
        {
            GameObject other = hitUp.collider.gameObject;

            while (other.transform.parent != null)
            {
                other = other.transform.parent.gameObject;
            }

            other.transform.parent = transform;
            other.gameObject.GetComponent<PlataformMove>().DestroyMyButton();
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

    public void DestroyMyButton()
    {
        Destroy(_myButton.gameObject);
    }
}
