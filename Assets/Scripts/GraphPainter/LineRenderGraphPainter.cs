using UnityEngine;

public class LineRenderGraphPainter : BaseGraphPainter
{
    [SerializeField,Range(0,1)] private float _width = 0.07f;
    protected override void DrawLine(Transform point1, Transform point2)
    {
        var line = CreateLineRenderOn(point1);

        line.SetPosition(0,point1.position);
        line.SetPosition(1,point2.position);
    }

    private LineRenderer CreateLineRenderOn(Transform startPoint)
    {
        var lineGO = new GameObject("Edge");
        lineGO.transform.SetParent(startPoint);
        
        var line=lineGO.AddComponent<LineRenderer>();
        line.startWidth = _width;
        line.endWidth = _width;

        return line;
    }
}
