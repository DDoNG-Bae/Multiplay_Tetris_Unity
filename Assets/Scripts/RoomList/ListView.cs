using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ListView : MonoBehaviour {

    public GameObject itemObject;

    public Transform content;

    public List<ItemData> itemList;

    void Start()
    {
        this.binding();
    }

    private void binding()
    {
        GameObject itemTemp;
        ItemObject itemObjectTemp;

        foreach(ItemData item in this.itemList)
        {
            itemTemp = Instantiate(this.itemObject) as GameObject;
            itemObjectTemp = itemTemp.GetComponent<ItemObject>();

            itemObjectTemp.setItem(item.name, item.host, item.isStart, item.onClick);

            itemTemp.transform.SetParent(this.content);
        }
    }
}