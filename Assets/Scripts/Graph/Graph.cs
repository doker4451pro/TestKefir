using System.Collections.Generic;
using Array2DEditor;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private Array2DBool _edges;
    [SerializeField] private VertexDFS[] _vertices;
    [SerializeField] private BaseGraphPainter _painter;
    
    public void ResetStateVertices()
    {
        _vertices[0].State = VertexDFSState.Base;
        for (int i = 1; i < _vertices.Length; i++)
        {
            _vertices[i].State=VertexDFSState.NotVisited;
        }
    }

    private void Start()
    {
        SetInfoInVertices();
        _painter.DrawGraph(_edges,_vertices);
    }
    
    private void SetInfoInVertices()
    {
        for (int i = 0; i < _edges.GridSize.x; i++)
        {
            var connectedVertices = GetConnectedVertices(i);
            _vertices[i]
                .SetConnectedVertices(connectedVertices)
                .SetGraph(this);
        }
    }
    
    private List<VertexDFS> GetConnectedVertices(int lineIndex)
    {
        var connectedVertices = new List<VertexDFS>();
        for (int j = 0; j < _edges.GridSize.y; j++)
        {
            if(_edges.GetCell(lineIndex,j))
                connectedVertices.Add(_vertices[j]);
        }

        return connectedVertices;
    }
    
}
