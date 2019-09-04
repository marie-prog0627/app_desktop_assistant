using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WebSocketSharp;
using System.Collections;

public class WSVoiceRecognition : MonoBehaviour
{
    private WebSocket ws_;
    private string key = "";
    public string Key {
        //取得
        get {return key;}
        //変更
        set {key = value;}
    }

    void Awake()
    {
        ws_ = new WebSocket("ws://127.0.0.1:12002");
        ws_.OnMessage += (sender, e) => {
            Debug.Log(e.Data); // 認識結果
            key = e.Data;
        };
        ws_.Connect();
    }

    void OnApplicationQuit()
    {
        ws_.Close();
    }
}
