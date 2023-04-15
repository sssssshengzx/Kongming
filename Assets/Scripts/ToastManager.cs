using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastManager : MonoBehaviour
{
    public static ToastManager Instance;
    public GameObject ToastFather;
    public GameObject toast;
    protected CanvasGroup cg;
    // Start is called before the first frame update
    void Awake()
    { 
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createAndDestroyToast()
    {
        toast = GameObject.Instantiate(this.toast, this.ToastFather.transform);      
        toast.SetActive(true);
        ToastChangeAlpha.instance.acti = true;
        //ToastChangeAlpha.instance.start();
        Destroy(toast, 1.5f);
    }

    public void DestroyToast()
    {
        Destroy(toast, 1.5f);
    }
}
