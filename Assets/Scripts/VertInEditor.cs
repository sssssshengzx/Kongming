using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertInEditor : MonoBehaviour
{
    private void Start()
    {
        Destroy(GetComponent<MeshRenderer>());
        Destroy(GetComponent<MeshFilter>());
    }
}
