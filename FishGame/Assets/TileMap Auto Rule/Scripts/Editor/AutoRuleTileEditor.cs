using UnityEngine;
using UnityEditor;

// ----------------------------------------------------------------------------
// Author: Alexandre Brull
// https://brullalex.itch.io/
// ----------------------------------------------------------------------------

[CustomEditor(typeof(TerrainAutoRuleTile))]
[CanEditMultipleObjects]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TerrainAutoRuleTile myScript = (TerrainAutoRuleTile)target;
        if (GUILayout.Button("Build Rule Tile"))
        {
            myScript.OverrideRuleTile();
        }
    }
}
