﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{

    public GameObject[] mBlockContainer = new GameObject[7];
    public Tetrimino CurBlock;

    public int mGridHeight = 23;
    public int mGridWidth = 11;

    public Transform[,] mGrid;
    public int[,] mTestGrid = new int[11, 23]; 

    
   


     private void Awake()
    {
        SpawnBlock();
        mGrid = new Transform[mGridWidth, mGridHeight];
        StartCoroutine(FallDown());
       
        
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void LeftBtnAction()
    {
         CurBlock.LeftMove();
       
    }

    public void RightBtnAction()
    {
        
          CurBlock.RightMove();
        
    }

    public void DownBtnAction()
    {

        CurBlock.DownMove();
    }

    public void RotateBtnAction()
    {
        CurBlock.Rotation();
    }

    public void BlockSaveBtnAction()
    {

    }

    public void StraightFallBtnAction()
    {

    }

    public void SpawnBlock()
    {
        int ti = Random.Range(0, 7);
        CurBlock = Instantiate<Tetrimino>(mBlockContainer[ti].GetComponentInChildren<Tetrimino>());
        CurBlock.transform.position = new Vector3(5, 19, 0);
        
        
    }

    public bool CheckIsInside(Vector3 tVec)
    {
        return (((int)tVec.x >=0) && ((int)tVec.x < mGridWidth) && (tVec.y > 0));
    }

    public Vector2 Round (Vector2 tVec)
    {
        return new Vector2(Mathf.Round(tVec.x), Mathf.Round(tVec.y));
    }

    public void GridUpdate(Tetrimino tTetrimino)
    {
        for(int tx = 0; tx<mGridWidth; tx++)
        {
            for(int ty=0; ty<mGridHeight; ty++)
            {
                if (mGrid[tx, ty] != null)
                {
                    if(mGrid[tx,ty].parent == tTetrimino.transform)
                    {
                        mGrid[tx, ty] = null;
                    }
                }
            }
        }

        foreach(Transform Block in tTetrimino.transform)
        {
            Vector2 tVec = Round(Block.position);

            if(tVec.y < mGridHeight)
            {
                mGrid[(int)tVec.x, (int)tVec.y] = Block;
            }
        }

    }

    public Transform GetGridTransform(Vector2 tVec)
    {
        if(tVec.y > mGridHeight -1)
        {
            return null;
        }
        else
        {
            return mGrid[(int)tVec.x, (int)tVec.y];
        }
    }

    public void UpdateTestGrid()
    {
       for(int tx =0; tx<11;tx++)
        {
            for(int ty=0;ty<23;ty++)
            {
                if(mGrid[tx,ty] == null)
                {
                    mTestGrid[tx, ty] = 1;
                }
                else
                {
                    mTestGrid[tx, ty] = 0;
                }
            }
        }
    }
    
    IEnumerator FallDown()
    {
        for(; ; )
        {
            CurBlock.DownMove();

            yield return new WaitForSeconds(0.5f);
        }
    }

    public bool IsRowFull(int tGridY)
    {
        for(int tx = 0; tx<mGridWidth; tx++)
        {
            if(mGrid[tx,tGridY] == null)
            {
                return false;
            }
            
        }
        return true;
    }

    public void DeleteBlock(int tGridY)
    {
        for(int tx=0; tx<mGridWidth; tx++)
        {
            Destroy(mGrid[tx, tGridY].gameObject);

            mGrid[tx, tGridY] = null;
        }
    }

    public void RowDown(int tGridY)
    {
        for(int tx=0; tx<mGridWidth; tx++)
        {
            if(mGrid[tx,tGridY] !=null)
            {
                mGrid[tx, tGridY - 1] = mGrid[tx, tGridY];

                mGrid[tx, tGridY] = null;

                mGrid[tx, tGridY - 1].position+= new Vector3(0, -1, 0);
            }
        }
    }

    public void AllRowDown(int tGridY)
    {
        for (int ti = tGridY; ti < mGridHeight;ti++)
        {
            RowDown(ti);
        }
    }

    public void DeleteRow()
    {
        for(int ty=0; ty<mGridHeight; ty++)
        {
            if(IsRowFull(ty)==true)
            {
                DeleteBlock(ty);

                AllRowDown(ty + 1);

                ty--;
            }
        }
    }

}
