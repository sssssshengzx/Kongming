using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PaperMaterialSwitcher : MonoBehaviour
{
    [SerializeField] Saver saver;
    public List<MeshRenderer> renderers;
    public Material targetMat;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (renderers != null)
            {
                foreach (var r in renderers)
                {
                    r.sharedMaterial = targetMat;
                }
            }
            saver.paperMat = targetMat;
        });
    }
}
