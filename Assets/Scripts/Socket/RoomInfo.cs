using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RoomInfo
{
    public int id;
    public string name;
    public string host;
    public int count;
    public int isStart;

    public void SetUp(int tid, string tname, string thost, int tcount,int tIsStart)
    {
        id = tid;
        name = tname;
        host = thost;
        count = tcount;
        isStart = tIsStart;
    }
}
