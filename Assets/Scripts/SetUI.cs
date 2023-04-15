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
            UIItemInfo info=go.GetComponent<UIItemInfo>();
            if (info != null)
            {
                go.SetActive(true);
            }
            else
            {
                continue;
            }           
            info.SetData(items[i]);
        }
    }
}
