using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;
using System;
using System.Text;

public class MultiGameScene : SingleGameScene
{



    public int[,] mOtherPlayerGridInfo_1;
    public int[,] mOtherPlayerGridInfo_2;
    public int[,] mOtherPlayerGridInfo_3;

    public GameObject[,] OtherGrid_1;
    public GameObject OtherEdge_1;


    public GameObject mBlock;
   
    public int[,] mCoordGrid;
    byte[] mBuffer;

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
        OtherGridInit();
     
    }

    public void OtherGridInit()
    {
        
        for(int tx=0; tx<mGridWidth; tx++)
        {
            for(int ty=0; ty<mGridHeight; ty++)
            {
                OtherGrid_1[tx, ty] = Instantiate<GameObject>(mBlock);
                OtherGrid_1[tx, ty].transform.parent = OtherEdge_1.transform;
                OtherGrid_1[tx, ty].transform.localPosition = new Vector3(tx + 1, ty + 1, 0);
                OtherGrid_1[tx, ty].gameObject.SetActive(false);


            }
        }
    }


    public void IncodeGridInfo()
    {
        mBuffer = intArrayToBuffer(mCoordGrid);

        string strCoordGrid = Convert.ToBase64String(mBuffer);

    }

    

    public void DecodeGridInfo(string OtherPlayerGridInfo)
    {
        string strGrid = OtherPlayerGridInfo.Substring(1, OtherPlayerGridInfo.Length - 2);
        byte[] tBuffer = strToBuffer2(strGrid);
        mOtherPlayerGridInfo_1 = bufferToIntArray(tBuffer, 2, 2);


    }

    public void OtherGridUpdate()
    {
        for(int tx =0; tx<mGridWidth;tx++)
        {
            for(int ty=0; ty<mGridHeight;ty++)
            {
                if(mOtherPlayerGridInfo_1[tx,ty] == 1)
                {
                    GameObject Block = Instantiate(mBlock);
                   // Block.transform.parent = OtherGrid_1.transform;
                    Block.transform.localPosition = new Vector3(tx + 1, ty + 1, 0);
                }
            }
        }
    }

    byte[] strToBuffer2(string str)
    {
        return Convert.FromBase64String(str);
    }

    int[,] bufferToIntArray(byte[] buffer, int rowSize, int colSize)
    {
        if (buffer.Length != rowSize * colSize * sizeof(int))
        {
            throw new ArgumentException("buffer.length is not equal (rowSize * colSize * sizeof(int))");
        }

        int[,] arr = new int[rowSize, colSize];
        Buffer.BlockCopy(buffer, 0, arr, 0, arr.Length * sizeof(int));
        return arr;
    }

    byte[] intArrayToBuffer(int[,] arr)
    {
        byte[] buffer = new byte[arr.Length * sizeof(int)];
        Buffer.BlockCopy(arr, 0, buffer, 0, buffer.Length);
        return buffer;
    }

    public void CoordGrid() // null이면 블럭존재, null아니면 블럭 없음
    {
        for (int tx = 0; tx < mGridWidth; tx++)
        {
            for (int ty = 0; ty < mGridHeight; ty++)
            {
                if (mGrid[tx, ty] == null)
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
