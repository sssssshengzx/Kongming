using SQLite4Unity3d;
using UnityEngine;
using TMPro;
using System.IO;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class CreateDB : MonoBehaviour
{
    public string DatabaseName = "kongming.db";
    private SQLiteConnection con;
    // Start is called before the first frame update
    void Start()
    {
        StartSync();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartSync()
    {
#if UNITY_EDITOR
           var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
        con = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);
       
        if (!File.Exists(dbPath))
        {
            Debug.Log("create a new database");
            CreateDBB();
        }
        
    }


    public void CreateDBB()
    {
        con.DropTable<KongDB>();
        con.CreateTable<KongDB>();
   
    }
}
