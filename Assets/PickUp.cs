using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Intractable , Item
{
    InventorySystem IS;
    public string Name { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        IS = Camera.main.gameObject.GetComponent<InventorySystem>();
        Name = "Key";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        IS.AddToInventory(this);
        Destroy(gameObject);
    }
}
