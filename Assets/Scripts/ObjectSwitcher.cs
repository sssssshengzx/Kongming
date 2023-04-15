using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ObjectSwitcher : MonoBehaviour
{
    [SerializeField] public List<GameObject> objectsToClose;
    [SerializeField] public List<GameObject> objectsToOpen;
    void Start()
    {
        Button b = GetComponent<Button>();
        b.onClick.AddListener(() =>
        {
            if (objectsToClose != null)
                foreach (var o in objectsToClose)
                    o.SetActive(false);
            if (objectsToOpen != null)
                foreach (var o in objectsToOpen)
                    o.SetActive(true);
        });
    }
}