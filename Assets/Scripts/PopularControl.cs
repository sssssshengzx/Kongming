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

    //按钮控制
    //返回首页按钮
    public void startBt()
    {
        Application.LoadLevel(1);
    }
    //目录的四个按钮
    public GameObject Canvas_Choose;
    public GameObject Canvas_Intro;
    public GameObject Canvas_Custom;
    public GameObject Canvas_Classify;
    public GameObject Canvas_Related;
    public void ButtonIntroControl()//简介
    {
        print("1");
        Canvas_Choose.SetActive(false);
        Canvas_Intro.SetActive(true);
    }
    public void ButtonCustomControl()//习俗
    {
        print("2");
        Canvas_Choose.SetActive(false);
        Canvas_Intro.SetActive(false);
        Canvas_Custom.SetActive(true);
    }
    public void ButtonClassifyControl()//分类
    {
        print("3");
        Canvas_Choose.SetActive(false);
        Canvas_Custom.SetActive(false);
        Canvas_Classify.SetActive(true);
    }
    public void ButtonRelatedControl()//相关事件
    {
        print("4");
        Canvas_Choose.SetActive(false);
        Canvas_Custom.SetActive(false);
        Canvas_Classify.SetActive(false);
        Canvas_Related.SetActive(true);
    }
    //简介页的按钮：返回首页
    public void ButtonIntroNextPage()
    {
        Canvas_Choose.SetActive(true);
        Canvas_Intro.SetActive(false);
        Canvas_Custom.SetActive(false);
        Canvas_Classify.SetActive(false);
        Canvas_Related.SetActive(false);
        print("button down");
    }
    //习俗页的按钮：上一页、下一页
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
