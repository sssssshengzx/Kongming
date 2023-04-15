using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintRaycaster : MonoBehaviour
{
    Texture2D origin;
    Texture2D cloned;
    public int radius;
    public int actualRadius => radius * cloned.width / 1024;
    public bool saveToSaver;
    public Saver saver;
    public int ind;
    //bool lastFrame;
    //Vector2Int lastPos;
    bool inited;
    public void Init()
    {
        inited = true;
        origin = (Texture2D)GetComponent<MeshRenderer>().material.GetTexture("_MainTex");
        cloned = new Texture2D(origin.width, origin.height, TextureFormat.RGBA32, false);
        cloned.SetPixels(origin.GetPixels());
        cloned.Apply();
        if (saveToSaver)
            saver.paintedMat[ind] = GetComponent<MeshRenderer>().material;
        GetComponent<MeshRenderer>().material.SetTexture("_MainTex", cloned);
    }
    void Update()
    {
        if (!inited)
            return;
        Ray ray;
#if UNITY_ANDROID
        if (Input.touchCount == 0)
            return;
        var touch = Input.GetTouch(0);
        ray = Camera.main.ScreenPointToRay(touch.position);
#else
        if (!Input.GetMouseButton(0))
            return;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
#endif
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit))
            return;
        if (hit.collider.gameObject != gameObject)
            return;
        Vector2 hitPos = hit.textureCoord;
        Vector2Int hitPixel = new Vector2Int(Mathf.RoundToInt(hit.textureCoord.x * cloned.width), Mathf.RoundToInt(hit.textureCoord.y * cloned.height));
        for (int i = Mathf.Max(0, hitPixel.x - radius); i <= Mathf.Min(hitPixel.x + radius, cloned.width - 1); ++i)
        {
            for (int j = Mathf.Max(0, hitPixel.y - radius); j <= Mathf.Min(hitPixel.y + radius, cloned.height - 1); ++j)
            {
                if (Vector2Int.Distance(hitPixel, new Vector2Int(i, j)) <= radius)
                {
                    cloned.SetPixel(i, j, Color.black);
                    //Debug.Log(new Vector2(i, j));
                }
            }
        }
        cloned.Apply();
    }
}