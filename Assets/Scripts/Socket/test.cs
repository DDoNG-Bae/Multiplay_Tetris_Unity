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
        });
    }
}
