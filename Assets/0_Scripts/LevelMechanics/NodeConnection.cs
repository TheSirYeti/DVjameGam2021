using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeConnection : MonoBehaviour
{
    public List<Node> nodes = new List<Node>();
    public List<GameObject> cables;

    public Node equippedNode;

    private void Start()
    {
        EventManager.Subscribe("ConnectNode", ConnectNode);
    }

    public void ConnectNode(object[] parameters)
    {
        cables[(int)parameters[0]].SetActive(true);
    }
    
}
