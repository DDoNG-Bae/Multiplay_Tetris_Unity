using System;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class ItemData{
    public string name;
    public string host;
    public bool isStart;

    public ItemData(string name, string host, bool isStart)
    {
        this.name = name;
        this.host = host;
        this.isStart = isStart;
    }
}
