using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ItemObject : MonoBehaviour {
    public Button item;
    public Text roomname;
    public Text count;
    public Text start;

    public void setItem(string name,int count,int start)
    {
        roomname.text = name;
        this.count.text = count.ToString();
        this.start.text = start.ToString();
    }

    void onClick()
    {
        SceneManager.LoadScene("Room2");
    }
}
