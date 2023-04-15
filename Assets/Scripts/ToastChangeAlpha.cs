using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.WSA;

public class ToastChangeAlpha : MonoBehaviour
{
    CanvasGroup cg;
    public static ToastChangeAlpha instance;
    public bool acti;
    private void Awake()
    {
        instance = this;        
    }
    private void OnEnable()
    {
        cg = GetComponent<CanvasGroup>();
        cg.alpha = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (acti)
        {
            cg = GetComponent<CanvasGroup>();
            //Debug.Log(cg.alpha);
            cg.alpha += 0.05f;
        }
    }

    IEnumerator changeAlpha()
    {
        cg = GetComponent<CanvasGroup>();
        cg.alpha += 0.2f;
        //Debug.Log(cg.alpha);
        yield return 0;
        
    }

    public void start()
    {
        StartCoroutine(changeAlpha());
    }
}
