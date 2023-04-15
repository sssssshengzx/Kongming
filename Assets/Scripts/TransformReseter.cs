using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformReseter : MonoBehaviour
{
    Vector3 localPosition;
    Vector3 localEularAngle;
    Vector3 localScale;
    private void Start()
    {
        localPosition = transform.localPosition;
        localEularAngle = transform.localEulerAngles;
        localScale = transform.localScale;
    }
    public void ResetTransform()
    {
        transform.localPosition = localPosition;
        transform.localScale = localScale;
        transform.localEulerAngles = localEularAngle;
    }
}
