using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct StateSprite {
    public string name;
    public Sprite sprite;
}

[Serializable]
public struct ToolNewState {
    public string tool;
    public string newState;
}

[Serializable]
public struct ToolStateChange {
    public string currentState;
    public ToolNewState[] mappings;
}

public class InteractableStates : MonoBehaviour
{
    // Public state of the tile
    // Should map to the `name` of a SpriteStage
    public string state;

    // All the sprites!
    public StateSprite[] spriteStates;

    // Private dictionary representation of sprites
    public Dictionary<string, Sprite> spriteStateDict = new Dictionary<string, Sprite>();

    public ToolStateChange[] stateChanges;
    // Dictionary representation of states, tools that can be used, 
    // and what the new state will be afterwards
    // { "initial": [{ "hoe": "tilled" }], "tilled": [{ "watering can": "watered" }]}
    public Dictionary<string, List<Dictionary<string, string>>> stateChangesDict = new Dictionary<string, List<Dictionary<string, string>>>();

    // Start is called before the first frame update
    void Start()
    {
        ConstructDicts();
        
        state = spriteStates[0].name;
    }

    private void ConstructDicts () 
    {
        // Converts SpriteState Struct Array into Dictionary
        for (var i = 0; i < spriteStates.Length; i++) 
        {
            spriteStateDict.Add(spriteStates[i].name, spriteStates[i].sprite);
        }

        // Converts ToolStateChange Struct Array into Dictionary 
        for (var i = 0; i < stateChanges.Length; i++)
        {
            stateChangesDict.Add(stateChanges[i].currentState, new List<Dictionary <string, string>>());

            List<Dictionary<string, string>> states = stateChangesDict[stateChanges[i].currentState];
            ToolNewState[] changes = stateChanges[i].mappings;

            for (var j = 0; j < changes.Length; j++)
            {
                states.Add(new Dictionary<string, string>() { 
                    { changes[j].tool, changes[j].newState } 
                });
            }
        }
        stateChangesDict.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Debug.Log);
    }
}
