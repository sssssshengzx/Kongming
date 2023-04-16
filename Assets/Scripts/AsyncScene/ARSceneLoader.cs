using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARSceneLoader : MonoBehaviour
{
    [SceneName] public string arScene;
    public static ARSceneLoader Instance;
    bool prevActive = true;
    AsyncOperation loading;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    private void Update()
    {
        if (loading != null)
            Debug.Log(loading.progress);
        int sceneCount = SceneManager.sceneCount;
        for (int i = 0; i < sceneCount; ++i)
        {
            var s = SceneManager.GetSceneAt(i);
            if (s.name == arScene)
            {
                prevActive = true;
                return;
            }
        }
        if (prevActive)
        {
            prevActive = false;
            loading = SceneManager.LoadSceneAsync(arScene);
            loading.allowSceneActivation = false;
        }
    }
    public void Load()
    {
        if (loading != null)
        {
            loading.allowSceneActivation = true;
        }
    }
}