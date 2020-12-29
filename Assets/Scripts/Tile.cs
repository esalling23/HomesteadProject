using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : BaseObject
{
    private GameObject place;

    private InteractableStates stateManager;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        stateManager = GetComponent<InteractableStates>();
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
}
