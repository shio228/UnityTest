using UnityEngine;
using WebSocketSharp;

public class WebSocketManager : MonoBehaviour
{
    private WebSocket ws;

    void Start()
    {
        ws = new WebSocket("ws://localhost:8000/ws");
        ws.OnOpen += (sender, e) => Debug.Log("WebSocket opened");
        ws.OnMessage += (sender, e) => Debug.Log("WebSocket message received: " + e.Data);
        ws.OnError += (sender, e) => Debug.Log("WebSocket error: " + e.Message);
        ws.OnClose += (sender, e) => Debug.Log("WebSocket closed");

        ws.Connect();
    }

    void OnDestroy()
    {
        if (ws != null)
        {
            ws.Close();
            ws = null;
        }
    }

    void Update()
    {
        if (ws.ReadyState == WebSocketState.Open)
        {
            ws.Send("Hello, WebSocket!");
        }
    }
}
