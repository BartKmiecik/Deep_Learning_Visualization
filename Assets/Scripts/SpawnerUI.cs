using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Spawner))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Spawner myScript = (Spawner)target;
        if (GUILayout.Button("Spawn"))
        {
            myScript.SpawnObjects();
        }
        if (GUILayout.Button("DestroyAll"))
        {
            myScript.DestroyAll();
        }
    }
}
