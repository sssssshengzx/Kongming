using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInfo : MonoBehaviour
{
    public Text Date;
    
    private RecordItem item;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    
}
