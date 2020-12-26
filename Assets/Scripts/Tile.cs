using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SpriteStage {
    public string name;
    public Sprite sprite;
}

public class Tile : GameObject
{
    // All the sprites!
    public SpriteStage[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0].sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate () {
        Debug.Log("activated");

        spriteRenderer.sprite = sprites[1].sprite;
    }

}
