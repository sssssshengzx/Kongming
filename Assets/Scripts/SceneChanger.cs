using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SceneName] public string targetScene;
    public void ChangeSceneTo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(targetScene);
    }
}
