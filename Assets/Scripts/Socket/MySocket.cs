using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;

public class MySocket : MonoBehaviour {
    private static Socket socket;
    private static string url = "http://ec2-52-78-8-84.ap-northeast-2.compute.amazonaws.com:3000/";

    public static Socket getInstance()
    {
        if(socket == null)
        {
            socket = Socket.Connect(url);
        }

        return socket;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
