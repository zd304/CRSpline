using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(CRSplinePath))]
public class CRSplinePathEditor : Editor
{
    void OnEnable()
    {
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.white;
    }

    void OnSceneGUI()
    {
        CRSplinePath _target = target as CRSplinePath;
        if (_target.enabled)
        {
            if (_target.nodes.Length > 0)
            {
                Undo.RecordObject(_target, "Adjust CRSpline Path");

                Handles.Label(_target.nodes[0], "Begin", style);
                if (_target.nodes.Length > 2)
                {
                    for (int i = 1; i < _target.nodes.Length - 1; ++i)
                    {
                        Handles.Label(_target.nodes[i], "Point(" + i + ")");
                    }
                }
                Handles.Label(_target.nodes[_target.nodes.Length - 1], "End", style);

                for (int i = 0; i < _target.nodes.Length; ++i)
                {
                    _target.nodes[i] = Handles.PositionHandle(_target.nodes[i], Quaternion.identity);
                }
            }
        }

    }

    GUIStyle style = new GUIStyle();
}