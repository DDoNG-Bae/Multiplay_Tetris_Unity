using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;
using System;
using System.Text;
using MyUtility;
public class MultiGameScene : SingleGameScene
{



    public int[,] mOtherPlayerGridInfo_1;
    public int[,] mOtherPlayerGridInfo_2;
    public int[,] mOtherPlayerGridInfo_3;

    public GameObject[,] OtherGrid_1;
    public GameObject OtherEdge_1;


    public GameObject mBlock;
   
    public int[,] mCoordGrid;
    string strCoordGrid;
    byte[] mBuffer;

    public Socket socket;
   




     private void Awake()
    {
        Init();
        

    }

    // Use this for initialization
    void Start()
    {
        socket = Login.socket;



        /*
         * res 
         * "ID" : Wrong ID
         * "PASS" Wrong PASSWORD
         * "SUCCESS" : LOGIN Success
         */
        socket.On("receiveGridInfo",receiveGridInfo);
    }

    void receiveGridInfo(string data)
    {
        string tmpStr = data.Substring(1, data.Length - 2);
        byte[] tmpBuffer = MBuffer.strToBuffer(tmpStr);
        mOtherPlayerGridInfo_1 = MBuffer.bufferToIntArray(tmpBuffer, 11, 23);
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
        OtherGridInit();
        StartCoroutine(FallDown());
       
     
    }

    public void OtherGridInit()
    {
        OtherGrid_1 = new GameObject[11, 23];
        for(int tx=0; tx<mGridWidth; tx++)
        {
            for(int ty=0; ty<mGridHeight; ty++)
            {

                OtherGrid_1[tx, ty] = Instantiate(mBlock);
                OtherGrid_1[tx, ty].transform.parent = OtherEdge_1.transform;
                OtherGrid_1[tx, ty].transform.localPosition = new Vector3(tx + 1, ty + 1, 0);
                OtherGrid_1[tx, ty].gameObject.SetActive(false);


            }
        }
    }


    public void IncodeGridInfo()
    {
        mBuffer = intArrayToBuffer(mCoordGrid);

        strCoordGrid = Convert.ToBase64String(mBuffer);

    }

    public override IEnumerator FallDown()
    {
        for (; ; )
        {
            CurBlock.DownMove();

            CoordGrid(); // 서버 전송용 배열로 변환
            IncodeGridInfo();
            socket.Emit("sendGridInfo", strCoordGrid);
            OtherGridUpdate();

            yield return new WaitForSeconds(0.5f);
        }
    }


    public void OtherGridUpdate()
    {
        for(int tx =0; tx<mGridWidth;tx++)
        {
            for(int ty=0; ty<mGridHeight;ty++)
            {
                if(mOtherPlayerGridInfo_1[tx,ty] == 1)
                {
                    OtherGrid_1[tx, ty].gameObject.SetActive(true);
                }
                else
                {
                    OtherGrid_1[tx, ty].gameObject.SetActive(false);
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
                    mCoordGrid[tx, ty] = 0;
                }
                else
                {
                    mCoordGrid[tx, ty] = 1;
                }
            }
        }
    }
    
    
}
