using System;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class ItemData{
    public string name;
    public string host;
    public bool isStart;
    public Button.ButtonClickedEvent onClick;
}
