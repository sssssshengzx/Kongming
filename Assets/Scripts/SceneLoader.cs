using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;
    public void LoadSceneAsync()
    {
        //LoadSceneMode.Additiveģʽ���ں�̨���س�������������ֹ��ǰ�����еĴ���ִ�С�
        
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
}
