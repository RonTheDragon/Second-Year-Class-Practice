using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Intractable
{
    InventorySystem IS;
    bool open;
    // Start is called before the first frame update
    void Start()
    {
        IS = Camera.main.gameObject.GetComponent<InventorySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        if (open)
        {
            Debug.Log("The Door Is Already Opened");
        }
        else if (IS.CheckIfInInventory("Key"))
        {
            open = true;
            Debug.Log("Door Opened");
            MapManagement.FirstDoorOpen = true;
            transform.position += transform.right * 2;
            IS.RemoveFromInventory("Key");
        }
    }
}
