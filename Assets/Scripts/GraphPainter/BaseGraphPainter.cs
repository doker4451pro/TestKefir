using UnityEngine;
using Array2DEditor;

public abstract class BaseGraphPainter : MonoBehaviour
{
    public void DrawGraph(Array2DBool edges, VertexDFS[] vertices)
    {
        for (int i = 0; i < edges.GridSize.x; i++)
        {
            //symmetric
            for (int j = 0; j < i; j++)
            {
                if(edges.GetCell(i,j))
                    DrawLine(vertices[i].transform,vertices[j].transform);
            }
        }
    }

    protected abstract void DrawLine(Transform point1, Transform point2);
}
