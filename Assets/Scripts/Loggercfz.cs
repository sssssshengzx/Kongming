using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loggercfz : MonoBehaviour
{
    public static Loggercfz Instance;
    public UnityEngine.UI.Text text;
    public UnityEngine.UI.Text text2;
    private void Start()
    {
        Instance = this;
    }
    public void Log_(string s)
    {
        text.text = s;
    }
    public static void Log(string s)
    {
        Instance.Log_(s);
    }

    public void Log2_(string s)
    {
        text2.text = s;
    }
    public static void Log2(string s)
    {
        Instance.Log2_(s);
    }
}
