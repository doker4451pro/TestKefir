using System.Collections.Generic;
using Array2DEditor;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private Array2DBool _edges;
    [SerializeField] private Vertex[] _vertices;
    [SerializeField] private BaseGraphPainter _painter;

    private void Start()
    {
        SetEdgesInVertices();
        _painter.DrawGraph(_edges,_vertices);
    }

    private void SetEdgesInVertices()
    {
        for (int i = 0; i < _edges.GridSize.x; i++)
        {
            var connectedVertices = new List<Vertex>();
            for (int j = 0; j < _edges.GridSize.y; j++)
            {
                if(_edges.GetCell(i,j))
                    connectedVertices.Add(_vertices[j]);
            }
            _vertices[i].SetConnectedVertices(connectedVertices);
        }
    }
}
