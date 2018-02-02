using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;

public class LogOut : MonoBehaviour {

    Socket socket;
    
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnApplicationQuit()
    {
        
        socket = Login.socket;
        socket.Emit("QuitApplication", "a");

    }
}
