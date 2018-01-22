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

            itemObjectTemp.name.text = item.name;
            itemObjectTemp.host.text = item.host;
            itemObjectTemp.item.onClick = item.onItemClick;

            itemTemp.transform.SetParent(this.content);
        }
    }
}