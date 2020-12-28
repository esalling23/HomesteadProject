using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        // Loop over all items to display in ItemBar
        for (var i = 0; i < items.Length; i++)
        {
            // If there's an item in this spot, display it's name
            if (items[i] != null) 
            {
                itemSlots[i].transform.Find("Text").GetComponent<Text>().text =  items[i].name;
            }
        }
    }

    void Update () 
    {
        // Determine if we've pressed a number on the keyboard to select a tool
        int pressedNumber = GetPressedNumber();

        if (pressedNumber != -1)
        {
            // Item bar change - select tools 1 - 9
            // Debug.Log("Pressed number " + pressedNumber.ToString());
            SetItem(pressedNumber);
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

    // SetItem method accepts a number
    // Should change the currently selected item based on index of itembar
    private void SetItem(int numKey) 
    {
        // The selectedSpot should be an index value
        // Take the key num like 1 and subtract 1 to get the index 0
        selectedSpot = numKey - 1;

        // Set selected slot to be active
        itemSlots[selectedSpot].GetComponent<ItemSlot>().SetSlotActive();
    }

    // GetItem method returns the item instance
    public Item GetItem() 
    {
        return items[selectedSpot];
    }    
}