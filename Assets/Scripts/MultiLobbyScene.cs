using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;
public class MultiLobbyScene : MonoBehaviour {

    public Room[] mRoomList;

    // Use this for initialization
    void Start() {

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
}
