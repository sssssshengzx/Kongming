using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
//using UnityEditor.MemoryProfiler;
using System.IO;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine.Networking;
using System.Linq;

public class DBManager : MonoBehaviour
{
    [Header("数据库名称")]
    public string dbFileName = "kongming.db";
    // 数据库路径
    private string path;
    // 数据库连接对象
    private SQLiteConnection con;
    // 数据库指令对象
    //private SqliteCommand command;
    // 数据库读取对象
    //private SqliteDataReader reader;

    private void Start()
    {



    }
    public void connectDB()
    {

    }
    public void initDB()
    {
#if UNITY_EDITOR
        // 在编辑器和window(打包)的路径是一样的
        var path = string.Format(@"Assets/StreamingAssets/{0}", dbFileName);



#elif UNITY_ANDROID
   if (!File.Exists(Application.persistentDataPath + "/" + dbFileName))
        {
            CopyFile(dbFileName);
        }
        
        path = string.Format("{0}/{1}", Application.persistentDataPath, dbFileName);

#endif
        //Debug.Log(path);
        //test.instance.txt.text = path;
        // 实例化数据库连接对象
        con = new SQLiteConnection(path,SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        // 打开连接
        //con.Open();
        // 实例化数据库指令对象
        //command = con.CreateCommand();

    }

    public static void CopyFile(string fileName)
    {

        if (Application.platform == RuntimePlatform.Android)
        {

            using (UnityWebRequest request = UnityWebRequest.Get(Application.streamingAssetsPath + "/" + fileName))
            {
                request.timeout = 3;
                request.downloadHandler = new DownloadHandlerFile(Application.persistentDataPath + "/" + fileName);//直接将文件下载到外存
                request.SendWebRequest();

                float time = Time.time;
                //下载完成后执行的回调
                while (!request.isDone)
                {
                }
                request.Abort();
                //默认值是true，调用该方法不需要设置Dispose()，Unity就会自动在完成后调用Dispose()释放资源。
                request.disposeDownloadHandlerOnDispose = true;
                request.Dispose();
            }
        }
        else
        {
            File.Copy(Application.streamingAssetsPath + "/" + fileName, Application.persistentDataPath + "/" + fileName, true);
        }
    }

    public void InsertData(string content,string date,string time)
    {
        var p = new KongDB
        {
            Content = content,
            Date = date,    
            Time = time 
        };
        con.Insert(p);
    }

    public List<string> SelectDataD()
    {
        List<string> list = new List<string>();
        var records=con.Table<KongDB>().ToList();
        foreach (var record in records)
        {
            list.Add(record.Date); // 将每个Player对象的Score字段的值添加到List<int>中
        }
        return list;
    }

    public List<string> SelectDataC()
    {
        List<string> list = new List<string>();
        var records = con.Table<KongDB>().ToList();
        foreach (var record in records)
        {
            list.Add(record.Content); // 将每个Player对象的Score字段的值添加到List<int>中
        }
        return list;
    }


    /*
    void copydb()
    {
        string dataSandBoxPath = "";
#if UNITY_ANDROID
        //安卓上运行时
        dataSandBoxPath = Application.persistentDataPath + "/"+ dbFileName;
        //这是你安卓的路径
        if (!Directory.Exists(Application.persistentDataPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath);
        }
#endif

        try
        {
            WWW loadWWW = new WWW("jar:file://" + Application.streamingAssetsPath + "!/assets/" + dbFileName);

            if (!File.Exists(dataSandBoxPath))
            {
                while (!loadWWW.isDone)
                {
                    //如果你用www创建数据库，这个不能省
                }

                File.WriteAllBytes(dataSandBoxPath, loadWWW.bytes);
                //自己研究
            }

        }
        catch (Exception e)
        {

        }
        path = "URI=file:" + dataSandBoxPath;
        
    }
    IEnumerator copyDbFile()
    {
        string dataSandBoxPath = Application.persistentDataPath + "/" + dbFileName;
        if (!Directory.Exists(Application.persistentDataPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath);
        }
        
        WWW loadWWW = new WWW(Path.Combine(Application.streamingAssetsPath, dbFileName));
        Debug.Log(Path.Combine(Application.streamingAssetsPath, dbFileName));
        yield return loadWWW;
        File.WriteAllBytes(dataSandBoxPath, loadWWW.bytes);
        path = "URI=file:" + dataSandBoxPath;
        test.instance.txt.text = path;

    }*/

    /*
    //插入数据
    public SqliteDataReader InsertValues(string tableName, string[] values)
    {
        string sql = "INSERT INTO " + tableName + " values (";
        foreach (var item in values)
        {
            sql += "'" + item + "',";
        }
        sql = sql.TrimEnd(',') + ")";

        Debug.Log("插入成功");
        return ExecuteQuery(sql);
    }*/

    /// <summary>
    /// 获取数据
    /// </summary>
    /// <param name="queryString"></param>
    /// <returns></returns>
    /// 
    /// 
    /*
    public List<string> GetDataBySqlQuery(string query)
    {
        List<string> list = new List<string>();
        try
        {
            string queryString = query;
            reader = ExecuteQuery(queryString);
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    object obj = reader.GetValue(i);
                    list.Add(obj.ToString());
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
        return list;
    }*/

    /*
    public SqliteDataReader ExecuteQuery(string queryString)
    {
        command.CommandText = queryString;
        reader = command.ExecuteReader();
        return reader;
    }*/

    //关闭数据库
    /*
    public void CloseDB()
    {
        if (command != null)
        {
            command.Cancel();
        }
        command = null;

        if (reader != null)
        {
            reader.Close();
        }
        reader = null;

        if (con != null)
        {
            //connection.Close();
        }
        con = null;

        Debug.Log("关闭数据库");
    }*/



    private void OnDestroy()
    {
        // 释放con
        if (con != null)
        {
            con.Close();
        }

    }

}
