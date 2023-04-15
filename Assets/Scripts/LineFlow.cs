using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFlow : MonoBehaviour
{
    [SerializeField] Material mat;
    private void Update()
    {
        mat.SetTextureOffset("_MainTex", Vector2.right * Time.time);
    }
}