using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FunctionCaller : MonoBehaviour
{
    public UnityEvent action;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            action.Invoke();
        });
    }
}
