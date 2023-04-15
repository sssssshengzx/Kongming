using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionGroup : MonoBehaviour
{
    public Image selectedRing;
    public void ResetSelected(RectTransform rt)
    {
        selectedRing.rectTransform.position = rt.position;
    }
}