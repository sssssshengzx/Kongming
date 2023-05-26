using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUI : MonoBehaviour
{
    public Transform itemTemp;
    public ScrollRect ItemScrollRect;
    private List<RecordItem> items;
    public GameObject nonCans;
    public GameObject cans;
    List<GameObject> spcitems = new List<GameObject>();
    public GameObject Wish_card;
    public Text wishcontent;
    public Text wishdate;
    // Start is called before the first frame update
    void Awake()
    {
        LoadItemData ld = GetComponent<LoadItemData>();
        //ld = new LoadItemData();
        this.items = new List<RecordItem>();
        this.items = ld.LoadData();
    }
    private void OnEnable()
    {
        if(items.Count > 0)
        {
            cans.SetActive(true);
            nonCans.SetActive(false);
            this.createAllItems();
        }
        else
        {
            cans.SetActive(false);
            nonCans.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject createSpecificItem()
    {
        GameObject go = GameObject.Instantiate(this.itemTemp.gameObject, this.ItemScrollRect.content);
        return go;
    }

    private void createAllItems()
    {
        for(int i = 0; i < items.Count; i++)
        {
            GameObject go = this.createSpecificItem();
            spcitems.Add(go);
            //Button button = go.GetComponent<Button>();
            //button.onClick.AddListener(() => OnItemButtonPressed(go));
            UIItemInfo info=go.GetComponent<UIItemInfo>();
            if (info != null)
            {
                go.SetActive(true);
                go.GetComponent<Text>().text = items[i].wishes;
            }
            else
            {
                continue;
            }           
            info.SetData(items[i]);
        }
    }

    public void OnItemButtonPressed(GameObject go)
    {
        foreach (GameObject instance in spcitems)
        {
            if (instance == go)
            {
                wishcontent.text= go.GetComponent<Text>().text;
                wishdate.text = go.transform.Find("Date").GetComponent<Text>().text.Insert(4,".");
                Debug.Log(go.GetComponent<Text>().text);
            }
        }
        Wish_card.SetActive(true);
    }

    public void OnCloseButtonPressed()
    {
        Wish_card.SetActive(false);
    }
}
