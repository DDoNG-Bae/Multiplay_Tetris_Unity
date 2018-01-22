using System;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class ItemData{
    public string name;
    public string host;

    public Button.ButtonClickedEvent onItemClick;
}
