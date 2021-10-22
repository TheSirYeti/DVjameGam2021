using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public NodeType nodeType;
    public bool isConnected;
    public bool isGrabbed;
    public NodeConnection nodes;


    public void EquipNode()
    {
        isGrabbed = true;
        nodes.equippedNode = this;
    }

    public void ConnectNode()
    {
        if (nodes.equippedNode.nodeType == nodeType)
        {
            EventManager.Trigger("ConnectNode", nodeType);
            Debug.Log("Conecto!");
            isConnected = true;
        }
        else { 
            Debug.Log("No conecto!");
            isGrabbed = false;
        } 
        nodes.equippedNode = null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.tag == "Player")
        {
            if (nodes.equippedNode == null)
            {
                EquipNode();
                Debug.Log("GRABBED");
            } else if (!isConnected && !isGrabbed)
            {
                ConnectNode();
                Debug.Log("CONNECTING");
            }
        }
    }
}



public enum NodeType
{
    RED,
    BLUE,
    GREEN
}
