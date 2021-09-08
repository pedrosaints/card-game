using UnityEngine;
using System.Collections.Generic;

public class LineRendererController : MonoBehaviour
{

    private LineRenderer line;
    public RectTransform[] points;

    public void Awake()
    {
        line = GetComponent<LineRenderer>();
    }


    public void Update()
    {
        CreateConnections();
    }

    public void CreateConnections()
    {
        // CreateConnections conecta cada ponto passado por uma linha.

        line.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            line.SetPosition(i, points[i].position);
        }
    }

}
