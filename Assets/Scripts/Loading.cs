using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Loading : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SceneName] public string targetScene;
    void Start()
    {
        StartCoroutine(DotDotDot());
    }
    IEnumerator DotDotDot()
    {
        float[] time = { .5f, .5f, 1.2f };
        for (int i = 0; i < 3; ++i)
        {
            while (time[i] >= 0)
            {
                yield return null;
                time[i] -= Time.deltaTime;
            }
            text.text += '.';
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(targetScene);
    }
}