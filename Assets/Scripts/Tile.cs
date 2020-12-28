using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SpriteState {
    public string name;
    public Sprite sprite;
}

public class Tile : BaseObject
{
    // All the sprites!
    public SpriteState[] sprites;

    // Private dictionary representation of sprites
    protected Dictionary<string, Sprite> spriteStateDict = new Dictionary<string, Sprite>();

    // Public state of the tile
    // Should map to the `name` of a SpriteStage
    public string state;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        state = sprites[0].name;
        spriteRenderer.sprite = sprites[0].sprite;
        
        // Converts Struct Array into Dictionary
        for (var i = 0; i < sprites.Length; i++) 
        {
            spriteStateDict.Add(sprites[i].name, sprites[i].sprite);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected void StateChangeEvent () 
    {
        spriteRenderer.sprite = spriteStateDict[state];
    }

    public virtual void Activate (string item) 
    {
        // Activating any tile should depend on the item being used
        // and the state of the tile
        Debug.Log("ACTIVATING....Current State: " + state);
    }

}
