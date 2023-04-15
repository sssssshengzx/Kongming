using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    Vector2 prev;
    float xzAngle, yAngle;
    float dist;
    float cx => Camera.main.transform.position.x;
    float cy => Camera.main.transform.position.y;
    float cz => Camera.main.transform.position.z;
    public float speed;
    void Update()
    {
        //#if UNITY_ANDROID
        //#else
        if (Input.GetMouseButtonDown(0))
        {
            prev = Input.mousePosition;
            xzAngle = GetXZAngle();
            yAngle = GetYAngle();
            dist = GetDist();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 pos = Input.mousePosition;
            float newXZAngle = xzAngle - (pos.x - prev.x) * speed;
            float newYAngle = Mathf.Max(-Mathf.PI / 16, Mathf.Min(yAngle - (pos.y - prev.y) * speed, Mathf.PI * 7 / 16));
            Debug.Log(newYAngle);
            Camera.main.transform.position = new Vector3(
                Mathf.Cos(newXZAngle) * Mathf.Cos(newYAngle),
                Mathf.Sin(newYAngle),
                Mathf.Sin(newXZAngle) * Mathf.Cos(newYAngle)) * dist;
            Camera.main.transform.LookAt(Vector3.zero);
        }
        //#endif
    }
    float GetDist()
    {
        return SqrtAABBCC(cx, cy, cz);
    }
    float GetXZAngle()
    {
        return Mathf.Atan2(cz, cx);
    }
    float GetYAngle()
    {
        return Mathf.Atan2(cy, SqrtAABB(cx, cz));
    }
    float SqrtAABB(float a, float b)
    {
        return Mathf.Sqrt(a * a + b * b);
    }
    float SqrtAABBCC(float a, float b, float c)
    {
        return Mathf.Sqrt(a * a + b * b + c * c);
    }
}
