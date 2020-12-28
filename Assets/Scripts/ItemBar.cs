using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBar : MonoBehaviour
{
    private const int SIZE = 9;
    // Public array of items
    public Item[] items = new Item[SIZE];
    public int selectedSpot = 0;

    private GameObject[] itemSlots;

    void Start () 
    {
        itemSlots = GameObject.FindGameObjectsWithTag("ItemSlot");
    }

    void Update () 
    {
        // Determine if we've pressed a number on the keyboard to select a tool
        int pressedNumber = GetPressedNumber();

        if (pressedNumber != -1)
        {
            // Item bar change - select tools 1 - 9
            Debug.Log("Pressed number " + pressedNumber.ToString());
            SetItem(pressedNumber);

            // Update item bar
            UpdateItemSprites();
        }
    }

    // https://answers.unity.com/questions/38943/public-fixed-size-array-in-inspector.html
    // Prevents inspector-resizing of the `items` array
    void OnValidate()
    {
        if (items.Length != SIZE)
        {
            Debug.LogWarning("Item array length cannot be changed");
            Array.Resize(ref items, SIZE);
        }
    }

    // https://forum.unity.com/threads/setting-an-integer-to-a-number-pressed.510688/
    // Loops over nums 1 - 9 & checks for input from each
    // If it finds input, returns the number. Otherwise returns -1
    private int GetPressedNumber()
    {
        for (int number = 0; number <= 9; number++)
        {
            if (Input.GetKeyDown(number.ToString()))
                return number;
        }

        return -1;
    }

    private void UpdateItemSprites() 
    {
        for (var i = 0; i < 9; i++)
        {
            Debug.Log(itemSlots[i]);
        }
        Debug.Log(itemSlots[0]);
    }

    // SetItem method accepts a number
    // Should change the currently selected item based on index of itembar
    private void SetItem(int numKey) 
    {
        // The selectedSpot should be an index value
        // Take the key num like 1 and subtract 1 to get the index 0
        selectedSpot = numKey - 1;

        Debug.Log(GetItem());
        // Highlight selected tool
        itemSlots[selectedSpot].GetComponent<ItemSlot>().SetSlotActive();
    }

    // GetItem method returns the item instance
    public Item GetItem() 
    {
        Debug.Log(items[selectedSpot]);
        return items[selectedSpot];
    }    
}