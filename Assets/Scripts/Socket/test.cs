using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using socket.io;
using UnityEngine.UI;
public class test : MonoBehaviour {

    // Use this for initialization
    Socket socket;
    JSONObject obj;
    public GameObject PopUp;
    public InputField Roomname;
    int roomNum;
    
   
   
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
            data =data.Substring(1, data.Length - 2);
            roomNum = int.Parse(data);
            Debug.Log(roomNum);
        });
    }

    public void getRoomList()
    {
        Debug.Log("getRoomList");
        socket.Emit("getRoomList", "ass", actionTest);

    }
    public void actionTest(string data)
    {
        Debug.Log(data);
        data = data.Substring(1, data.Length - 2);
        //Debug.Log(d);
        string str = fixJson(data);
        Debug.Log(str);
        RoomInfo[] roomInfo = JsonHelper.FromJson<RoomInfo>(str);
        //JsonHelper.FromJson<RoomInfo>(str)
        Debug.Log(roomInfo[1].id);
        Debug.Log(roomInfo[1].name);

        List<RoomInfo> RoomList = roomInfo.OfType<RoomInfo>().ToList();

        int ti = 0;
        Refresh(RoomList);

        //Debug.Log(jobj["qwer"]["user"]["asd"]["id"]);
        //for (int i = 0; i < jobj.list.Count; i++)
        //{
        //    string roomName = jobj.keys[i];
        //    string host = jobj.list[i]["host"].str;
        //    bool isStart = jobj.list[i]["isStart"].b;
        //    Debug.Log("roomList[" + i + "] roomName " + roomName + "host " + host + " isStart " + isStart);

        //    roomList.Add(new ItemData(roomName, host, isStart));
        //    scrollView.binding(roomList);

        //}
    }

    public void Refresh(List<RoomInfo> RoomList)
    {
        scrollView.Delete();
        scrollView.binding(RoomList);
       
    }

  
    public void getRoom()
    {
        socket.Emit("getRoomList", "", (string data) =>
          {
              RoomInfo[] roomInfo = JsonHelper.FromJson<RoomInfo>(data);
              //JsonHelper.FromJson<>
              Debug.Log(roomInfo[0].id);
              Debug.Log(roomInfo[0].name);
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
    string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }

    public void OnCreatePopUp()
    {
        PopUp.gameObject.SetActive(true);

    }

    public void CreateRoom()
    {
        createRoom(Roomname.text);
    }

    public void CancelPopUp()
    {
        PopUp.gameObject.SetActive(false);
    }

    
}
