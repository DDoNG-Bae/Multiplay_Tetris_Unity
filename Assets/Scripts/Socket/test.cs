using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using socket.io;
public class test : MonoBehaviour {

    // Use this for initialization
    Socket socket;
    JSONObject obj;
    public List<ItemData> roomList;
    
    public ScrollView scrollView;

    void Start () {
        socket = Login.socket;
        createRoom("qwer");
        getRoomList();
        joinRoom("qwer");
        
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
        socket.Emit("getRoomList", "dsa", actionTest);

    }
    public void actionTest(string data)
    {
        Debug.Log(data);
        JSONObject jobj = new JSONObject(data).list[0];
        //Debug.Log(jobj["qwer"]["user"]["asd"]["id"]);
        for (int i = 0; i < jobj.list.Count; i++)
        {
            string roomName = jobj.keys[i];
            string host = jobj.list[i]["host"].str;
            bool isStart = jobj.list[i]["isStart"].b;
            Debug.Log("roomList[" + i + "] roomName " + roomName + "host " + host + " isStart " + isStart);

            roomList.Add(new ItemData(roomName, host, isStart));
            scrollView.binding(roomList);

        }
    }
}
