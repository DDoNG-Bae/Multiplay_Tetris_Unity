using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;
using System;
using System.Text;

public class MultiGameScene : SingleGameScene
{

  
   
    public int[,] mCoordGrid;
    public int[] testGrid;

    public Socket socket;
   


     private void Awake()
    {
        Init();

    }

    // Use this for initialization
    void Start()
    {
        socket = Socket.Connect("http://ec2-52-78-8-84.ap-northeast-2.compute.amazonaws.com:3000/" + "channel");

        /*
         * res 
         * "ID" : Wrong ID
         * "PASS" Wrong PASSWORD
         * "SUCCESS" : LOGIN Success
         */
        socket.On("loginResult", (string res) => {
            Debug.Log(res);

            if (res == "\"SUCCESS\"")
            {
               
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void Init()
    {
        SpawnBlock();
        mGrid = new Transform[mGridWidth, mGridHeight];
        mCoordGrid = new int[mGridWidth, mGridHeight];
        StartCoroutine(FallDown());
        SendGridInfo();
     
    }


    public void SendGridInfo()
    {
       

        StringBuilder CoordStr = new StringBuilder();

        for(int tx= 0; tx<mGridWidth; tx++)
        {
            for(int ty=0; ty<mGridHeight; ty++)
            {
                CoordStr.Append(mCoordGrid[tx, ty].ToString());
            }
        }

        string test = CoordStr.ToString();

        //serversend for convert CoordStr.ToString();
      


        int th = 0;

    }

    public void DecodeGrid(string OtherPlayerGridInfo)
    {
        int[,] OtherPlayerGrid = new int[11, 23];

        for(int tx=0; tx<OtherPlayerGrid.GetLength(0); tx++)
        {
            for(int ty = 0;ty < OtherPlayerGrid.GetLength(1);ty++)
            {
                
            }
        }
    }


    public void CoordGrid() // null이면 블럭존재, null아니면 블럭 없음
    {
        for(int tx =0; tx<mGridWidth; tx++)
        {
            for(int ty=0; ty<mGridHeight; ty++)
            {
                if(mGrid[tx,ty] == null)
                {
                    mCoordGrid[tx, ty] = 1;
                }
                else
                {
                    mCoordGrid[tx, ty] = 0;
                }
            }
        }
    }
    
}
