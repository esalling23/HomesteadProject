using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : Item 
{
    void Start () 
    {
        type = "tool";
    }

    public override void Use (Vector2 direction) 
    {
        Debug.Log((Vector2)transform.position);
        Debug.Log(direction);

        // Cast a ray straight down in front of us.
        Vector2 position = (Vector2)transform.position + direction;
        Debug.Log(position);
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down);

        // If it hits something that is not the player...
        if (hit.collider != null && hit.transform != null && (string)hit.transform.name != "Player")
        {
            Debug.Log("We hit something");
            Debug.Log(hit.transform.name);
            Tile tileScript = hit.collider.gameObject.GetComponent<Tile>();
            tileScript.Activate();
        }
    }
}