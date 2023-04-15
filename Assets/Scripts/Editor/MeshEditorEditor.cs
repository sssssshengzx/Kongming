using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshEditor))]
public class MeshEditorEditor : Editor
{
    //private void OnSceneGUI()
    //{
    //    var o = target as MeshEditor;
    //    var q = o.transform.rotation;
    //    foreach(var v in o.vertices)
    //    {
    //        Handles.Label(v.position, v.name, new GUIStyle { normal = new GUIStyleState { textColor = Color.black, background = Texture2D.whiteTexture } });
    //    }
    //}
}
