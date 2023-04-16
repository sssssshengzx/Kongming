using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSceneWaker : MonoBehaviour
{
    public void Load()
    {
        ARSceneLoader.Instance.Load();
    }
}
