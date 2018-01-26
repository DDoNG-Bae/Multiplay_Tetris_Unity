using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using socket.io;

public class MultiLobbyScene : MonoBehaviour {

    public Room[] mRoomList;
    Socket socket;
    // Use this for initialization
    void Start() {
        socket = Login.socket;
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
            Debug.Log("getRoomList : " + data);
            JSONObject obj = new JSONObject(data);
        });
     }
   
}
