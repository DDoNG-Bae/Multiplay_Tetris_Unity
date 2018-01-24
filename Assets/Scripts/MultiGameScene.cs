using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;

public class MultiGameScene : SingleGameScene
{

  
   
    public int[,] mCoordGrid;
  

   


     private void Awake()
    {
        Init();

    }

    // Use this for initialization
    void Start()
    {

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
        string ti = mCoordGrid.ToString();
        int tx = 0;
    }

    public void CoordGrid() // null이면 블럭존재, null아니면 블럭 없음
    {
        for(int ty =0; ty<mGridHeight; ty++)
        {
            for(int tx=0; tx<mGridWidth; tx++)
            {
                if(mGrid[ty,tx] == null)
                {
                    mCoordGrid[ty, tx] = 1;
                }
                else
                {
                    mCoordGrid[ty, tx] = 0;
                }
            }
        }
    }
    
}
