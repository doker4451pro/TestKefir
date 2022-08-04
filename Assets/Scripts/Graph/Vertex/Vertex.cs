using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    private List<Vertex> _connectedVertices;

    public void SetConnectedVertices(List<Vertex> newConnectedVertices)
    {
        if (_connectedVertices == null)
            _connectedVertices = newConnectedVertices;
        else
            Debug.LogError("_connectedVertices already set");
    }
    
}
