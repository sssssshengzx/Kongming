using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordItem
{
    public string wishes;
    public string Date;
    public string Location;
    
    
    public RecordItem(string wishes,string Date,string Location)
    {
        this.Location = Location;
        this.Date = Date;  
        this.wishes = wishes;
    }
    public RecordItem()
    {

    }

    public RecordItem(string wishes,string Date)
    {
        this.Date = Date;
        this.wishes = wishes;
    }

}
