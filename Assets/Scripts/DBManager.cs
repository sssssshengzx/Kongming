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
    [Header("���ݿ�����")]
    public string dbFileName = "kongming.db";
    // ���ݿ�·��
    private string path;
    // ���ݿ����Ӷ���
    private SQLiteConnection con;
    // ���ݿ�ָ�����
    //private SqliteCommand command;
    // ���ݿ��ȡ����
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
        // �ڱ༭����window(���)��·����һ����
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
        // ʵ�������ݿ����Ӷ���
        con = new SQLiteConnection(path,SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        // ������
        //con.Open();
        // ʵ�������ݿ�ָ�����
        //command = con.CreateCommand();

    }

    public static void CopyFile(string fileName)
    {

        if (Application.platform == RuntimePlatform.Android)
        {

            using (UnityWebRequest request = UnityWebRequest.Get(Application.streamingAssetsPath + "/" + fileName))
            {
                request.timeout = 3;
                request.downloadHandler = new DownloadHandlerFile(Application.persistentDataPath + "/" + fileName);//ֱ�ӽ��ļ����ص����
                request.SendWebRequest();

                float time = Time.time;
                //������ɺ�ִ�еĻص�
                while (!request.isDone)
                {
                }
                request.Abort();
                //Ĭ��ֵ��true�����ø÷�������Ҫ����Dispose()��Unity�ͻ��Զ�����ɺ����Dispose()�ͷ���Դ��
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
            list.Add(record.Date); // ��ÿ��Player�����Score�ֶε�ֵ��ӵ�List<int>��
        }
        return list;
    }

    public List<string> SelectDataC()
    {
        List<string> list = new List<string>();
        var records = con.Table<KongDB>().ToList();
        foreach (var record in records)
        {
            list.Add(record.Content); // ��ÿ��Player�����Score�ֶε�ֵ��ӵ�List<int>��
        }
        return list;
    }


    /*
    void copydb()
    {
        string dataSandBoxPath = "";
#if UNITY_ANDROID
        //��׿������ʱ
        dataSandBoxPath = Application.persistentDataPath + "/"+ dbFileName;
        //�����㰲׿��·��
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
                    //�������www�������ݿ⣬�������ʡ
                }

                File.WriteAllBytes(dataSandBoxPath, loadWWW.bytes);
                //�Լ��о�
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
    //��������
    public SqliteDataReader InsertValues(string tableName, string[] values)
    {
        string sql = "INSERT INTO " + tableName + " values (";
        foreach (var item in values)
        {
            sql += "'" + item + "',";
        }
        sql = sql.TrimEnd(',') + ")";

        Debug.Log("����ɹ�");
        return ExecuteQuery(sql);
    }*/

    /// <summary>
    /// ��ȡ����
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

    //�ر����ݿ�
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

        Debug.Log("�ر����ݿ�");
    }*/



    private void OnDestroy()
    {
        // �ͷ�con
        if (con != null)
        {
            con.Close();
        }

    }

}
