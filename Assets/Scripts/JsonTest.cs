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
        int[,] arr = new int[11,23];


        for(int i = 0; i<11; i++)
        {
            for (int j = 0; j < 23; j++)
            {
                arr[i, j] = 0;
            }
        }

        byte[] buffer = intArrayToBuffer(arr);
       //string str = BitConverter.ToString(buffer);//case 1

        string str = Convert.ToBase64String(buffer);//case 2
        //byte[] buffer2 = strToBuffer(str);
        //int[,] arr2 = bufferToIntArray(buffer2, 2, 2);

        Debug.Log(str.Length);

        socket.On("result",result);
        socket.On("connect", () =>{
            socket.Emit("test",str);
        });
         
	}


    byte[] strToBuffer2(string str)
    {
        return Convert.FromBase64String(str);
    }

    byte[] strToBuffer(string str)
    {
        String[] arr = str.Split('-');
        byte[] buffer = new byte[arr.Length];
        for (int i = 0; i < buffer.Length; i++)
            buffer[i] = Convert.ToByte(arr[i], 16);

        return buffer;
    }

    int[,] bufferToIntArray(byte[] buffer,int rowSize,int colSize)
    {
        if(buffer.Length != rowSize * colSize * sizeof(int))
        {
            throw new ArgumentException("buffer.length is not equal (rowSize * colSize * sizeof(int))");
        }
            
        int[,] arr = new int[rowSize, colSize];
        Buffer.BlockCopy(buffer, 0, arr, 0, arr.Length * sizeof(int));
        return arr;
    }

    byte[] intArrayToBuffer(int[,] arr)
    {
        byte[] buffer = new byte[arr.Length*sizeof(int)];
        Buffer.BlockCopy(arr, 0, buffer,0, buffer.Length);
        return buffer;
    }

    

    void result(string data)
    {
        Debug.Log(data);
        Debug.Log(data.Length);
        string str = data.Substring(1, data.Length - 2);
        Debug.Log(str);
        byte[] buffer3 = strToBuffer2(str);
        int[,] arr3 = bufferToIntArray(buffer3, 11, 23);
        Debug.Log(arr3[1, 1]);
    }

	// Update is called once per frame
	void Update () {
		
	}
    
}
