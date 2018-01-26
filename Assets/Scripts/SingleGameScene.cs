using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGameScene : MonoBehaviour
{
    public GameObject[] mBlockContainer = new GameObject[7];
    public Tetrimino CurBlock;
    public Tetrimino NextBlock;
    public Tetrimino SaveBlock;

    public int mGridHeight = 23;
    public int mGridWidth = 11;

    public Camera mCamera;
    public Transform NextBlockUIPos;
    public Transform SaveBlockUIPos;

    public Transform[,] mGrid;
    public int[,] mTestGrid = new int[11, 23];

    public int mScore = 0;







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

    public virtual void Init()
    {
        SpawnBlock();
        mGrid = new Transform[mGridWidth, mGridHeight];
        StartCoroutine(FallDown());

     
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
        if (SaveBlock == null)
        {

            SaveBlock = CurBlock;
            SaveBlock.transform.position = CoordBlockPos(SaveBlockUIPos.position);
            SaveBlock.enabled = false;
            GridUpdate(SaveBlock);
            SpawnBlock();
        }
        else
        {



        }
    }

    public void StraightFallBtnAction()
    {

    }

    public void SpawnBlock()
    {
        int tCurType = Random.Range(0, 7);
        int tNextType = Random.Range(0, 7);

        if (NextBlock == null)
        {
            CurBlock = Instantiate<Tetrimino>(mBlockContainer[tCurType].GetComponentInChildren<Tetrimino>());
            CurBlock.transform.position = new Vector3((mGridWidth + 1) / 2, mGridHeight - 2, 0);

            NextBlock = Instantiate<Tetrimino>(mBlockContainer[tNextType].GetComponentInChildren<Tetrimino>());
            NextBlock.transform.position = CoordBlockPos(NextBlockUIPos.position);
            NextBlock.enabled = false;

        }
        else
        {
            CurBlock = NextBlock;
            CurBlock.transform.position = new Vector3((mGridWidth + 1) / 2, mGridHeight - 2, 0);

            NextBlock = Instantiate<Tetrimino>(mBlockContainer[tNextType].GetComponentInChildren<Tetrimino>());
            NextBlock.transform.position = CoordBlockPos(NextBlockUIPos.position);
        }

        CurBlock.SetScene(this);

    }

    public bool CheckIsInside(Vector3 tVec)
    {
        return (((int)tVec.x >= 0) && ((int)tVec.x < mGridWidth) && (tVec.y > 0));
    }

    public Vector2 Round(Vector2 tVec)
    {
        return new Vector2(Mathf.Round(tVec.x), Mathf.Round(tVec.y));
    }

    public void GridUpdate(Tetrimino tTetrimino)
    {

        for (int tx = 0; tx < mGridWidth; tx++)
        {
            for (int ty = 0; ty < mGridHeight; ty++)
            {
                if (mGrid[tx, ty] != null)
                {
                    if (mGrid[tx, ty].parent == tTetrimino.transform)

                    {
                        mGrid[tx, ty] = null;
                    }
                }
            }
        }
      

        foreach (Transform Block in tTetrimino.transform)
        {
            Vector2 tVec = Round(Block.position);

            
            if (tVec.y < mGridHeight)
            {
                mGrid[(int)tVec.x, (int)tVec.y] = Block;

            
            }
           
        }
     

    }

    public Transform GetGridTransform(Vector2 tVec)
    {
        if (tVec.y > mGridHeight - 1)
        {
            return null;
        }
        else
        {
            return mGrid[(int)tVec.x, (int)tVec.y];
        }
    }

    public void UpdateTestGrid()  //네트워크 전송용 Grid 업데이트
    {
        for (int tx = 0; tx < 11; tx++)
        {
            for (int ty = 0; ty < 23; ty++)
            {
                if (mGrid[tx, ty] == null)
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

    public IEnumerator FallDown()
    {
        for (; ; )
        {
            CurBlock.DownMove();

            yield return new WaitForSeconds(0.5f);
        }
    }

    public bool IsRowFull(int tGridY) // 해당 열이 전부 차있는지 체크
    {
        for (int tx = 0; tx < mGridWidth; tx++)
        {
            if (mGrid[tx, tGridY] == null)
            {
                return false;
            }

        }
        return true;
    }

    public void DeleteBlock(int tGridY) //전부 차있는 열의 블록 삭제
    {
        for (int tx = 0; tx < mGridWidth; tx++)
        {
            Destroy(mGrid[tx, tGridY].gameObject);

            mGrid[tx, tGridY] = null;
        }
    }

    public void RowDown(int tGridY)
    {
        for (int tx = 0; tx < mGridWidth; tx++)
        {
            if (mGrid[tx, tGridY] != null)
            {
                mGrid[tx, tGridY - 1] = mGrid[tx, tGridY];

                mGrid[tx, tGridY] = null;

                mGrid[tx, tGridY - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public void AllRowDown(int tGridY) //블록 삭제 후 해당 열 위에 위치한 모든 열의 블록을 y축으로 -1씩 내림
    {
        for (int ti = tGridY; ti < mGridHeight; ti++)
        {
            RowDown(ti);
        }
    }

    public void DeleteRow()
    {
        for (int ty = 0; ty < mGridHeight; ty++)
        {
            if (IsRowFull(ty) == true)
            {
                DeleteBlock(ty);

                AllRowDown(ty + 1);

                ty--;

                ScoreUp();
            }
        }
    }

    public void ScoreUp()
    {
        mScore += 100;
    }

    public Vector3 CoordBlockPos(Vector3 tUIPos) // NextBlock, SaveBlock 배치를 위한 UI POS 보정(Screen->world)
    {
        Vector3 tCoordVec;

        mCamera = Camera.main;

        tCoordVec = mCamera.ScreenToWorldPoint(tUIPos);

        tCoordVec = new Vector3(tCoordVec.x, tCoordVec.y - 3, 0);


        return tCoordVec;
    }

}
