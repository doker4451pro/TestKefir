using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Vertex))]
public class VertexDFS : MonoBehaviour
{
    [SerializeField] private VertexDFSState _state;
    private Vertex _vertex;
    private List<VertexDFS> _connectedVertices;
    private Graph _graph;

    public VertexDFSState State
    {
        get { return _state;}
        set { _state = value; }
    }

    private void Awake()
    {
        _vertex = GetComponent<Vertex>();
    }
    
    public VertexDFS SetConnectedVertices(List<VertexDFS> newConnectedVertices)
    {
        if (_connectedVertices == null)
            _connectedVertices = newConnectedVertices;
        else
            Debug.LogError("_connectedVertices already set");
        return this;
    }

    public VertexDFS SetGraph(Graph graph)
    {
        if (_graph == null)
            _graph = graph;
        else
            Debug.LogError("_graph already set");

        return this;
    }

    public bool IsThereStudiedVertexInConnectedVertices()
    {
        foreach (var connectedVertex in _connectedVertices)
        {
            if (connectedVertex._vertex.State == VertexState.Studied)
                return true;
        }

        return false;
    }

    public bool CanFindWayToBase()
    {
        _graph.ResetStateVertices();
        foreach (var vertex in _connectedVertices)
        {
            if (vertex._vertex.State == VertexState.Studied)
            {
                _state = VertexDFSState.Visited;
                if (!DFS(vertex))
                    return false;
            }
        }
        return true;
    }

    private bool DFS(VertexDFS vertexDFS)
    {
        if (vertexDFS._state == VertexDFSState.Base || vertexDFS._state==VertexDFSState.ToBase)
            return true;
        if (vertexDFS._state == VertexDFSState.Visited)
            return false;

        vertexDFS._state = VertexDFSState.Visited;

        foreach (var connectedVertex in vertexDFS._connectedVertices)
        {
            if (connectedVertex._vertex.State == VertexState.Studied && connectedVertex._state != VertexDFSState.Visited)
            {
                if (DFS(connectedVertex))
                {
                    vertexDFS._state = VertexDFSState.ToBase;
                    return true;
                }
                else
                    return false;
            }
        }

        return false;
    }
}
