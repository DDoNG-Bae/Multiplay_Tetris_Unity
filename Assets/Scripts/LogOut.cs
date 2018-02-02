using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;

public class LogOut : MonoBehaviour {

    Socket socket;
    string ti = "aa";
	// Use this for initialization
	void Start () {
<<<<<<< HEAD
        
=======
       
>>>>>>> 418411f657ecbc2a2370f2fdc1937348f3b8ca9f
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnApplicationQuit()
    {
<<<<<<< HEAD
        socket = Login.socket;
        Debug.Log("logout");
        socket.Emit("QuitApplication");
=======
        
        socket = Login.socket;
        socket.Emit("QuitApplication", "a");
>>>>>>> 418411f657ecbc2a2370f2fdc1937348f3b8ca9f
    }
}
