using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemObject : MonoBehaviour {
    public Button item;
    public Text name;
    public Text host;
    public Text start;

    public void setItem(string name,string host,bool start, Button.ButtonClickedEvent onClick)
    {
        this.name.text = name;
        this.host.text = host;
        if (start)
            this.start.text = "start";
        else
            this.start.text = "wait";
        this.item.onClick = onClick;
    }
}
