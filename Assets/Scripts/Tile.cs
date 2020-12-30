using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : BaseObject
{
    private GameObject place;

    private StateManager stateManager;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        stateManager = GetComponent<StateManager>();
        spriteRenderer.sprite = stateManager.spriteStates[0].sprite;

        place = GameObject.Find("Place");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected void StateChangeEvent () 
    {
        spriteRenderer.sprite = stateManager.spriteStateDict[stateManager.state];
    }

    public virtual void Activate (string item) 
    {
        // Activating any tile should depend on the item being used
        // and the state of the tile
        Debug.Log("ACTIVATING....Current State: " + stateManager.state);

        // Based on current state + item being used, modify tile state
        List<Dictionary<string, string>> toolOptions = stateManager.stateChangesDict[stateManager.state];
        Debug.Log(toolOptions);

        for (var i = 0; i < toolOptions.Count; i++) {
            Debug.Log(toolOptions[i]);
            if (toolOptions[i].ContainsKey(item)) {
                stateManager.state = toolOptions[i][item];
            }
        }

        // After changing state, trigger state change event
        // TODO: actually use events not methods....
        StateChangeEvent();
    }

    public bool CanPlace(Item item) 
    {
        switch (label) 
        {
            case "ground":
                // Workable ground
                // Can only place seeds if the tile has a certain stage
                if ((stateManager.state == "watered" ^ stateManager.state == "tilled") && item.label == "seeds") 
                {
                    return true;
                } else if (item.label == "seeds")  {
                    return false;
                }

                return true;
                break;
        
            case "impassable":
                // This tile is impassable, we can't place anything here
                return false;
                break;

            default:
                // 
                return true;
                break;

            
        }
    }
}
