using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopularControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //��ť����
    //������ҳ��ť
    public void startBt()
    {
        Application.LoadLevel(1);
    }
    //Ŀ¼���ĸ���ť
    public GameObject Canvas_Choose;
    public GameObject Canvas_Intro;
    public GameObject Canvas_Custom;
    public GameObject Canvas_Classify;
    public GameObject Canvas_Related;
    public void ButtonIntroControl()//���
    {
        print("1");
        Canvas_Choose.SetActive(false);
        Canvas_Intro.SetActive(true);
    }
    public void ButtonCustomControl()//ϰ��
    {
        print("2");
        Canvas_Choose.SetActive(false);
        Canvas_Intro.SetActive(false);
        Canvas_Custom.SetActive(true);
    }
    public void ButtonClassifyControl()//����
    {
        print("3");
        Canvas_Choose.SetActive(false);
        Canvas_Custom.SetActive(false);
        Canvas_Classify.SetActive(true);
    }
    public void ButtonRelatedControl()//����¼�
    {
        print("4");
        Canvas_Choose.SetActive(false);
        Canvas_Custom.SetActive(false);
        Canvas_Classify.SetActive(false);
        Canvas_Related.SetActive(true);
    }
    //���ҳ�İ�ť��������ҳ
    public void ButtonIntroNextPage()
    {
        Canvas_Choose.SetActive(true);
        Canvas_Intro.SetActive(false);
        Canvas_Custom.SetActive(false);
        Canvas_Classify.SetActive(false);
        Canvas_Related.SetActive(false);
        print("button down");
    }
    //ϰ��ҳ�İ�ť����һҳ����һҳ
    public void ButtonCustomNextPage()
    {

        Canvas_Custom.SetActive(true);
    }
    public void ButtonCustomLastPage()
    {
        print("1");
        Canvas_Intro.SetActive(true);
    }
}
