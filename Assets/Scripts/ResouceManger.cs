using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResouceManger : MonoBehaviour {

    public GameObject GridBlock;
    public GameObject[] BlockArray = new GameObject[7];
    static private ResouceManger Inst;

    static public ResouceManger GetInst()
    {
        if(Inst == null)
        {
            Inst = new ResouceManger();
        }
        return Inst;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
   
}
