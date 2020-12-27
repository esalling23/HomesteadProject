using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : BaseObject
{
    public string name;
    public int price;

    public string type;

    void Start () 
    {
        
    }

    public void Use (Vector2 playerPosition, Vector2 direction) 
    {
        // Debug.Log((Vector2)playerPosition);
        // Debug.Log(direction);

        switch (type)
        {
            case "tool":
                // Cast a ray straight down in "front" of the player.
                Vector2 position = (Vector2)playerPosition + direction;
                // Debug.Log(position);
                RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down);

                // If it hits something that is not the player...
                if (hit.collider != null && hit.transform != null && (string)hit.transform.name != "Player")
                {
                    Debug.Log("We hit something");
                    Debug.Log(hit.transform.name);
                    Tile tileScript = hit.collider.gameObject.GetComponent<Tile>();
                    tileScript.Activate();
                }
                break;

            case "edible": 
                Debug.Log("Nom nom nom");
                break;

            default: 
                Debug.Log("Used the item " + name);
                break;
        }

        
    }
}