using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollView : MonoBehaviour {

    public GameObject itemObject;
    public Transform content;
    //public List<ItemData> itemList;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void binding(List<ItemData> itemList)
    {
        GameObject itemTemp;
        ItemObject itemObjectTemp;

        foreach (ItemData item in itemList)
        {
            itemTemp = Instantiate(itemObject) as GameObject;
            itemObjectTemp = itemTemp.GetComponent<ItemObject>();

            itemObjectTemp.setItem(item.name, item.host, item.isStart);

            itemTemp.transform.SetParent(this.content);
        }
    }
}
