using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;
using UnityEngine.UI;
public class Login : MonoBehaviour {
    public InputField idInput;
    public InputField passInput;

    Socket socket;
	// Use this for initialization
	void Start () {
        socket = Socket.Connect("http://ec2-52-78-8-84.ap-northeast-2.compute.amazonaws.com/");
        
        socket.On("loginResult",(string res)=>{
            Debug.Log(res);
        });

    }

    public void login()
    {
        User2 user = new User2();
        user.id = idInput.text;
        user.pass = passInput.text;

        socket.EmitJson("login",JsonUtility.ToJson(user));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class User2
{
    public string id;
    public string pass;
}