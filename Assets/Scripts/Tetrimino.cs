using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrimino : MonoBehaviour {

    bool mIsBind = false;
    public SingleGameScene mpScene;
   


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
        this.transform.Rotate(0, 0, 90);
        if (CheckPosition() == true)
        {

        }
        else
        {
            this.transform.Rotate(0, 0, -90);
        }
       
    }

    
    public void DownMove()
    {
        this.transform.position += new Vector3(0, -1, 0);

        if(CheckPosition() == false)
        {
            this.transform.position += new Vector3(0, 1, 0);

            mpScene.DeleteRow();

            mIsBind = true;

            mpScene.SpawnBlock();
        }
        else
        {
            mpScene.GridUpdate(this);

        }
    }

    public bool CheckPosition()
    {
        foreach(Transform Block in transform)
        {
            Vector2 tVec = mpScene.Round(Block.position);

            if(mpScene.CheckIsInside(tVec)==false)
            {
                return false;
            }

            if (mpScene.GetGridTransform(tVec) != null && mpScene.GetGridTransform(tVec).parent != transform)
            {
                return false;
                
            }

        }
        return true;
    }

    public void SetScene(SingleGameScene tpScene)
    {
        mpScene = tpScene;
    }
  
}
