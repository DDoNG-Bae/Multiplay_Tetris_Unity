﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;
using UnityEngine.UI;

public class reg : MonoBehaviour {
    public InputField idInput;
    public InputField passInput1;
    public InputField passInput2;
    public InputField nameInput;
    public InputField phoneInput;
    public Button idCheckBtn;
    public Button submitBtn;

    Socket socket;

	// Use this for initialization
	void Start () {
        socket = Socket.Connect("http://ec2-52-78-8-84.ap-northeast-2.compute.amazonaws.com:3000/" + "regist");
        socket.On("regResult", (string code) =>
         {
             Debug.Log("regResult" + code);
         });

        socket.On("idDup", (string code) =>
         {
             Debug.Log("check ID code : " + code);
         });
        		




	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void submit()
    {
        User user = new User();
        user.id = idInput.text;
        user.pass = passInput1.text;
        user.pass2 = passInput2.text;
        user.name = nameInput.text;
        user.phone = phoneInput.text;

        socket.EmitJson("register",JsonUtility.ToJson(user));

    }

    public void checkID()
    {
        //@"{ ""my"": ""data"" }"
        socket.Emit("checkID", idInput.text);
        // @"{ ""pass"":" + passInput1.text + ", ""pass2"":" + passInput2.text + " }"
    }

}

public class User
{
    public string id;
    public string pass;
    public string pass2;
    public string name;
    public string phone;
}