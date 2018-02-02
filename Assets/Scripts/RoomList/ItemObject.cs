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

    public void setItem(string name,int tcount,int tstart)
    {
        roomname.text = name;
        count.text = tcount.ToString();
        start.text = tstart.ToString();
       
    }

    void onClick()
    {
        SceneManager.LoadScene("Room2");
    }
}
