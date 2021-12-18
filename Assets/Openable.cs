using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : Intractable
{
    bool open;
    public GameObject[] Contant;

    // Start is called before the first frame update
    void Start()
    {
        ShowContact(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        open = !open;
        if (open)
        {
            Debug.Log("Cabinet Opened");
            ShowContact(true);
        }
        else
        {
            Debug.Log("Cabinet Closed");
            ShowContact(false);
        }
    }

    void ShowContact(bool Show)
    {
        foreach(GameObject g in Contant)
        {
            g.SetActive(Show);
        }
    }
}
