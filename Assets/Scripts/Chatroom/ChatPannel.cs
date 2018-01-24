using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatPannel : MonoBehaviour {
    public GameObject chatingObject;
    public Transform chatPanel;

	public void binding(string name, string message)
    {
        GameObject obj;
        ChatingObject chatingTemp;
        
        obj = Instantiate(chatingObject) as GameObject;
        chatingTemp = obj.GetComponent<ChatingObject>();

        chatingTemp.id.text = name;
        chatingTemp.message.text = message;

        obj.transform.SetParent(this.chatPanel);
        obj.transform.localPosition = new Vector3(0, 0, 0);
    }
}
