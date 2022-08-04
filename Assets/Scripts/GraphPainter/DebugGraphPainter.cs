using UnityEngine;

public class DebugGraphPainter : BaseGraphPainter
{
    protected override void DrawLine(Transform point1, Transform point2)
    {
        Debug.DrawLine(point1.position,point2.position,Color.red,float.MaxValue);
    }
}
