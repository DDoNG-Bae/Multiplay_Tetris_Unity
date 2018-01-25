using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;
using System.Text;
public class JsonTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var socket = Socket.Connect("http://ec2-52-78-8-84.ap-northeast-2.compute.amazonaws.com:3000/");
        test tes = new test();
        int[,] arr = new int[2, 2] { { 1, 2 }, { 3, 4 } };
        byte[] buffer = new byte[4 * sizeof(int)];
        Buffer.BlockCopy(arr, 0, buffer, 0, buffer.Length);
        int[,] arr2 = new int[2,2];
        Buffer.BlockCopy(buffer, 0, arr2, 0, buffer.Length);
        for(int i =0; i<buffer.Length; i++)
        {
            Debug.Log(buffer[i]);
        }
        //string str = Convert.ToBase64String(buffer);

        Debug.Log(arr[0,1]);
        JSONObject obj = new JSONObject();

        socket.On("result", (string data) =>
         {
             
             Debug.Log(data);
             //Convert.
         });
        socket.On("connect", () =>{
            //socket.Emit("test",str);
        });
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public class test
    {
       public int[,] arr;
    }
}
