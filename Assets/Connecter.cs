using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Connecter : MonoBehaviour
{
    //接続するURL
    private const string URL = "http://localhost:5000";

    // インスタンス化
    public static Connecter instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Connect();
    }

    // http通信を行うコルーチンを呼び出す
    public void Connect()
    {
        //コルーチンを呼び出す
        StartCoroutine("OnSend", URL);
    }

    //コルーチン
    IEnumerator OnSend(string url)
    {
        //URLをGETで用意
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        //URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();

        //エラーが出ていないかチェック
        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            //通信失敗
            Debug.Log(webRequest.error);
        }
        else
        {
            //通信成功
            Debug.Log(webRequest.downloadHandler.text);
        }
    }
}