using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{

    public GameObject[] mBlockContainer = new GameObject[7];
    public Tetrimino CurBlock;

    public int mGridHeight = 23;
    public int mGridWidth = 11;

    public Transform[,] mGrid;
   


     private void Awake()
    {
        SpawnBlock();
        mGrid = new Transform[mGridWidth, mGridHeight];
        
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

    public void FallDownBtnAction()
    {

        CurBlock.FallDown();
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
        CurBlock.transform.position = new Vector3(0, 20.5f, 0);
        
    }

    public bool CheckIsInside(Vector3 tVec)
    {
        return (((int)tVec.x >=-mGridWidth) && ((int)tVec.x < mGridWidth) && (tVec.y > 0));
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
    

}
