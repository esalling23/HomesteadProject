using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{

    public Sprite sprite;
    // protected so it is inherited but not exposed
    protected SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        spriteRenderer = gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>();
    }
}