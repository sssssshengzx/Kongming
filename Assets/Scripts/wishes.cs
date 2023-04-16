using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wishes : MonoBehaviour
{
    public Text wish;
    string content;
    string date;
    string time;
    DBManager dbManager;
    public GameObject wisharea;
    public GameObject toast;
    public GameObject toastFather;
    public GameObject ill;
    
    //public Text txt;
    private void OnEnable()
    {
        if (!wisharea.activeSelf)
        {
            wisharea.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        dbManager = new DBManager();
        dbManager.connectDB();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnWishButtonPressed()
    {
        content = wish.text;
        if (content == "")
        {
            ToastManager.Instance.toast = this.toast;
            ToastManager.Instance.ToastFather = this.toastFather;
            toast.GetComponentInChildren<Text>().text = "������Ը��������ԸŶ~";
            ToastManager.Instance.createAndDestroyToast();
        }
        else
        {
            date = System.DateTime.Now.ToString("yyyy-MM-dd");
            time = System.DateTime.Now.ToString("HH:mm:ss");          
            string[] query = { content, date, time };
            dbManager.initDB();
            dbManager.InsertData(content, date, time);
            
            //dbManager.InsertValues("���������ݼ��װ�", query);
            //txt.text = "insert successful";
            //dbManager.CloseDB();
            toast.GetComponentInChildren<Text>().text = "Ը����д������ƣ�";
            ToastManager.Instance.toast = this.toast;
            ToastManager.Instance.ToastFather = this.toastFather;
            ToastManager.Instance.createAndDestroyToast();
            
            wisharea.SetActive(false);
            StartCoroutine(OpenIllToast());          
        }
        
        //dbManager.InsertValues
    }

    IEnumerator OpenIllToast()
    {
        yield return new WaitForSeconds(1.8f);
        ill.SetActive(true);
        StartCoroutine(CloseIllToast());
    }
    IEnumerator CloseIllToast()
    {
        yield return new WaitForSeconds(2f);
        ill.SetActive(false);
    }

    
}
