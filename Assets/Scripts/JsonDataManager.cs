using System;
using System.IO;
using UnityEngine;

public class JsonDataManager
{
    /// <summary>
    /// パスを取得　＆　セーブファイル名記録
    /// </summary>
    private static string getFilePath()
    {
        return Application.persistentDataPath + "VolumeSaveData" + ".json";
    }

    /// <summary>
    /// 書き込み機能
    /// </summary>
    
    public static void Save(Data data)
    {
        // シリアライズ実行
        string jsonSerializedData = JsonUtility.ToJson(data);
        Debug.Log(jsonSerializedData);

        // ファイル作って書き込む
        using (var sw = new StreamWriter(getFilePath(), false))
        {
            try
            {
                // ファイルに書き込む
                sw.Write(jsonSerializedData);
            }
            catch (Exception e)// 失敗した時の処理
            {
                Debug.Log(e);
            }
        }
    }

    /// <summary>
    /// 読み込み機能
    /// </summary>

    public static Data Load()
    {
        Data jsonDeserializedData = new Data();

        try
        {
            // ファイルを読み込む
            using (FileStream fs = new FileStream(getFilePath(), FileMode.Open))
            using (StreamReader st = new StreamReader(fs))
            {
                string result = st.ReadToEnd();
                Debug.Log(result);

                // 読み込んだjsonを構造体に入れる
                jsonDeserializedData = JsonUtility.FromJson<Data>(result);
            }
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }

        // デシリアライズした構造体を返す
        return jsonDeserializedData;
    }

}
