using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectTypeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnterSingleScene()
    {
        SceneManager.LoadScene("SingleGameScene");
    }

    public void EnterMultiScene()
    {
        SceneManager.LoadScene("MultiLobbyScene");
    }
}
