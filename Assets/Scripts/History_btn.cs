using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class History_btn : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnFlyButtonPressed()
    {
        SceneManager.LoadScene("ARAll");
    }
    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("ARAll");
    }
}
