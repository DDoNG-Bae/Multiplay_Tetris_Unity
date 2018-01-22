using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;

public class MultiLobbyScene : MonoBehaviour {

    public Room[] mRoomList;
    Socket socket;
    // Use this for initialization
    void Start() {
        createRoom("asd");

        getRoomList();
    }

    // Update is called once per frame
    void Update() {

    }

    public void EnterRoom(Room tRoom)
    {

    }

    public class Room
    {
        int mPlayerNum;
        string mRoomName;

    }

    void createRoom(string room)
    {
        socket.Emit("createRoom", room, (string data) =>
          {
              Debug.Log("createRooM : " + data);
          });
    }

    void getRoomList()
    {
        socket.Emit("getRoomList","\"dsa\"",(string data) =>{
            Debug.Log("getRoomList" + data);
        });
    }
}
