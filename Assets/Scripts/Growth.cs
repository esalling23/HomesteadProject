using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct GrowthTime {
    // Should map to a state in the state manager
    public string state;
    public float wait;
}

public class Growth : BaseObject
{

    private int growthLevel = 0;
    private StateManager stateManager;

    public GrowthTime[] growthTimes;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        stateManager = GetComponent<StateManager>();
        // Start growth process
        StartCoroutine(RunStage((float)10.0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RunStage(float time)
    {
        while (stateManager.state != "ripe") {
            Debug.Log("Time to wait...Current State: " + stateManager.state);
            yield return new WaitForSeconds(time);
            growthLevel++;
            stateManager.state = stateManager.spriteStates[growthLevel].state;
            spriteRenderer.sprite = stateManager.spriteStateDict[stateManager.state];
            // RunStage((float)10.0);
        }
    }
}
