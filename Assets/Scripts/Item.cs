using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : BaseObject
{
    public string label;
    public int price;
    
    // How much health/stamina is provided by this item
    public int health;
    public int stamina;

    public string type;

    private Player player;

    protected override void Start () 
    {
        base.Start();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void Use (Tile tile) 
    {
        switch (type)
        {
            case "tool":
                tile.Activate(label);
                break;

            case "consumable": 
                Debug.Log("Nom nom nom");
                player.Consume(health, stamina);
                break;

            case "placeable":
                Debug.Log("PUT THAT DOWN");
                // Literally...put it down
                Instantiate(gameObject, tile.transform);
                break;

            default: 
                Debug.Log("Used the item " + label);
                break;
        }
    }
}