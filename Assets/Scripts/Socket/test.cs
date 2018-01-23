using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;
public class test : MonoBehaviour {

    // Use this for initialization
    Socket socket;
    void Start () {
        socket = Login.socket;

        createRoom("asd");
        getRoomList();
        joinRoom("asd");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void joinRoom(string room)
    {
        Debug.Log("joinRoom");
        socket.Emit("joinRoom", room, (string data) =>
          {
              Debug.Log("joinRoom " + data);
          });
    }
    void createRoom(string room)
    {
        Debug.Log("createRooM");
        socket.Emit("createRoom", room, (string data) =>
        {
            Debug.Log("createRooM : " + data);
        });
    }

    void getRoomList()
    {
        Debug.Log("getRoomList");
        socket.Emit("getRoomList", "dsa", (string data) => {
            Debug.Log("getRoomList" + data);
            JSONObject obj = new JSONObject(data);
            Debug.Log("json : " + (string)obj.keys[0]);
            //accessData(obj);
        });
    }


    void accessData(JSONObject obj)
    {
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
