using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : GameObject
{
    public string name;
    public int price;

    public string type;

    void Start () 
    {
        
    }

    public virtual void Use(Vector2 direction)
    {
        Debug.Log("Using item " + name);
    }
}