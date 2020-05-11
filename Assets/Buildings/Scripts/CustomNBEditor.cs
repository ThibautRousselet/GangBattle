using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Neighborhood))]
[CanEditMultipleObjects]
public class LookAtPointEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Neighborhood nb = (Neighborhood)target;
        nb.UpdateDisplay();
    }
}