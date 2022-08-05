using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Vertex))]
public class VertexDFS : MonoBehaviour,IPointerClickHandler
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

    public bool CanFindWayToBase()
    {
        _graph.ResetStateVertices();
        var way = new List<VertexDFS>();
        var a=DFS(this,way);
        foreach (var temp in way)
        {
            Debug.Log(temp);
        }

        return a;
    }

    private bool DFS(VertexDFS vertexDFS,List<VertexDFS> way)
    {
        if (vertexDFS._state == VertexDFSState.Base)
            return true;
        if (vertexDFS._state == VertexDFSState.Visited)
            return false;

        vertexDFS._state = VertexDFSState.Visited;
        
        foreach (var obj in vertexDFS._connectedVertices)
        {
            if (obj._vertex.State == VertexState.Studied && obj._state != VertexDFSState.Visited)
            {
                if (DFS(obj,way))
                {
                    way.Add(obj);
                    return true;
                }
                else
                {
                    way.Remove(obj);
                    return false;
                }
            }
        }
        
        return false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(CanFindWayToBase());
    }
}
