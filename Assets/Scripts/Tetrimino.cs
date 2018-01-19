using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrimino : MonoBehaviour {

    bool mIsBind = false;
    public GameScene mpScene;


	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public bool IsBind()
    {
        return mIsBind;
    }

    public void LeftMove()
    {
          this.transform.position += new Vector3(-1, 0, 0);

        if (CheckPosition() == false)
        {
            this.transform.position += new Vector3(1, 0, 0);
        }
        
        
    }
    public void RightMove()
    {
        this.transform.position += new Vector3(1, 0, 0);

        if (CheckPosition() == false)
        {
            this.transform.position += new Vector3(-1, 0, 0);
        }
    }
    public void Rotation()
    {
        if(CheckPosition() == true)
        {
            this.transform.Rotate(0, 0, 90);
        }
       
    }
    public void DownMove()
    {
        this.transform.position += new Vector3(0, -1, 0);

        if(CheckPosition() == false)
        {
            this.transform.position += new Vector3(0, 1, 0);

            FindObjectOfType<GameScene>().DeleteRow();

            mIsBind = true;

            FindObjectOfType<GameScene>().SpawnBlock();
        }
        else
        {
            FindObjectOfType<GameScene>().GridUpdate(this);

        }
    }

    public bool CheckPosition()
    {
        foreach(Transform Block in transform)
        {
            Vector2 tVec = FindObjectOfType<GameScene>().Round(Block.position);

            if(FindObjectOfType<GameScene>().CheckIsInside(tVec)==false)
            {
                return false;
            }

            if (FindObjectOfType<GameScene>().GetGridTransform(tVec) != null && FindObjectOfType<GameScene>().GetGridTransform(tVec).parent != transform)
            {
                return false;
                
            }

        }
        return true;
    }

    public void SetScene(GameScene tpScene)
    {
        mpScene = tpScene;
    }
}
