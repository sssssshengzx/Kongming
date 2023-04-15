using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadItemData : MonoBehaviour
{
    DBManager dbManager;
    private RecordItem item;
    private List<RecordItem> records;
    // Start is called before the first frame update
    void Start()
    {
        dbManager = new DBManager();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<RecordItem> LoadData()
    {
        dbManager = new DBManager();
        dbManager.initDB();
        //string conquery = "SELECT Ը������ FROM ���������ݼ��װ�";
        //string datequery = "SELECT �ŷ����� FROM ���������ݼ��װ�";
        List<string> wishcontent = dbManager.SelectDataC();
        //dbManager.CloseDB();
        //dbManager.initDB();
        List<string> flydate = dbManager.SelectDataD();
        //Debug.Log(wishcontent.Count);
        //Debug.Log(flydate.Count);
        records = new List<RecordItem>();
        for (int i = 0; i < wishcontent.Count; i++)
        {       
            string str=flydate[i].Replace("-",".").Remove(4,1);
            Debug.Log(str);
            item=new RecordItem(wishcontent[i],str);
            records.Add(item);
        }
        return records;

    }
}
