using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CRSplinePath : MonoBehaviour
{
    void Awake()
    {
        if (mPathes.ContainsKey(gameObject.name))
        {
            Debug.LogError("CR样条线路径名重复：" + gameObject.name);
            //Destroy(gameObject);
            return;
        }
        mPathes.Add(gameObject.name, this);

        spline = new CRSpline(nodes);
    }

    void OnDestroy()
    {
        mPathes.Remove(gameObject.name);
    }

    void DrawPath(Color color)
    {
        if (nodes.Length == 0)
            return;

        Vector3 pervPt = spline.Interp(0);

        Gizmos.color = color;
        int SmoothAmount = nodes.Length * 20;
        for (int i = 1; i <= SmoothAmount; ++i)
        {
            float pm = (float)i / SmoothAmount;
            Vector3 curPt = spline.Interp(pm);

            Gizmos.DrawLine(curPt, pervPt);

            pervPt = curPt;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (nodes.Length >= 2 && !Application.isPlaying)
            spline.Reset(nodes);
        DrawPath(Color.cyan);

        Vector3 center = Vector3.zero;
        for (int i = 0; i < nodes.Length; ++i)
        {
            Vector3 node = nodes[i];
            center += node;
        }
        center /= nodes.Length;
        transform.position = center;
    }

    public static CRSplinePath GetPathByName(string name)
    {
        CRSplinePath path;
        if (!mPathes.TryGetValue(name, out path))
            return null;
        return path;
    }

    public Vector3[] nodes = new Vector3[] { Vector3.zero, Vector3.zero };

    [System.NonSerialized]
    public CRSpline spline = null;

    static Dictionary<string, CRSplinePath> mPathes = new Dictionary<string, CRSplinePath>();
}