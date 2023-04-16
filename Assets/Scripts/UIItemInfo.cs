using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInfo : MonoBehaviour
{
    public Text Date;
    //public Text Wish_content;
    private RecordItem item;
    // Start is called before the first frame update
    void Start()
    {
        //Wish_content = GameObject.Find("wishcontent").GetComponent<Text>();
    }

    public void SetData(RecordItem item)
    {
        if (item == null)
        {
            Debug.Log("item is null");
            return;
        }
        this.item = item;

        this.Date.text=item.Date;
        //this.Wish_content.text=item.wishes;
    }
    
}
