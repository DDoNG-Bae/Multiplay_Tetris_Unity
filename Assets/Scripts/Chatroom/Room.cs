using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using socket.io;
public class Room : MonoBehaviour {

    Socket socket;
    public ChatPannel chatPannel;
    public InputField msg;
	// Use this for initialization
	void Start () {
        socket = Login.socket;

        socket.On("getMessage", (string data)=>{
            Debug.Log(data);
            JSONObject jo = new JSONObject(data);
            string id = jo["name"].str;
            string message = jo["message"].str;
            Debug.Log(id + " : " + message);
            chatPannel.binding(id, message);

            //accessData(jo);
        });
        
    }
	
    void chating(string data)
    {
        Debug.Log(data);
        JSONObject jo = new JSONObject(data);
        string name = jo["name"].str;
        string message = jo["message"].str;
        chatPannel.binding(name, message);
    }

    public void sendMessage()
    {
        socket.Emit("chatMessage", msg.text);
    }

	// Update is called once per frame
	void Update () {
		
	}

    void accessData(JSONObject obj)
    {
        Debug.Log(obj.type);
        switch (obj.type)
        {
            case JSONObject.Type.OBJECT:
                for (int i = 0; i < obj.list.Count; i++)
                {
                    string key = (string)obj.keys[i];
                    JSONObject j = (JSONObject)obj.list[i];
                    Debug.Log(key);
                    accessData(j);
                }
                break;
            case JSONObject.Type.ARRAY:
                foreach (JSONObject j in obj.list)
                {
                    accessData(j);
                }
                break;
            case JSONObject.Type.STRING:
                Debug.Log(obj.str);
                break;
            case JSONObject.Type.NUMBER:
                Debug.Log(obj.n);
                break;
            case JSONObject.Type.BOOL:
                Debug.Log(obj.b);
                break;
            case JSONObject.Type.NULL:
                Debug.Log("NULL");
                break;

        }
    }
}
