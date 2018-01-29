using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;

public class LogOut : MonoBehaviour {

    Socket socket; string ti = "aa";
	// Use this for initialization
	void Start () {
        socket = Login.socket;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnApplicationQuit()
    {
        socket.Emit("QuitApplication", "a");
    }
}
