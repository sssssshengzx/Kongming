using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;
    public void LoadSceneAsync()
    {
        //LoadSceneMode.Additive模式将在后台加载场景，而不会阻止当前场景中的代码执行。
        
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
}
