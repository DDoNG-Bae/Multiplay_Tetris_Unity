using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollView : MonoBehaviour {

    public GameObject itemObject;
    public Transform content;
    public List<ItemData> itemList;

	// Use this for initialization
	void Start () {
        binding();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void binding()
    {
        GameObject tempObj;
        ItemObject tempItemObj;

        foreach(ItemData item in this.itemList)
        {
            tempObj = Instantiate(this.itemObject) as GameObject;
            tempItemObj = tempObj.GetComponent<ItemObject>();

            tempItemObj.setItem(item.name, item.host, item.isStart, item.onClick);

            tempObj.transform.SetParent(this.content);
        }
    }
}
