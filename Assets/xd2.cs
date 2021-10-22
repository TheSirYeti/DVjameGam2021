using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xd2 : MonoBehaviour
{
    //VectoresMouse
    Vector2 mousePos = new Vector2();
    Vector3 point = new Vector3();

    void Update()
    {
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;

        point = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 15));
        //point.y = 1;

        transform.position = point;
    }
}
