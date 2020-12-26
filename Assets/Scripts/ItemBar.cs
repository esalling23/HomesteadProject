using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBar : MonoBehaviour
{
    void Start () 
    {

    }

    void Update () 
    {

        // Determine if we've pressed a number on the keyboard to select a tool
        int pressedNumber = GetPressedNumber();

        if (pressedNumber != -1)
        {
            // Tool bar change - select tools 1 - 9
            Debug.Log("Pressed number " + pressedNumber.ToString());
            // ToolBar.ChangeTool(pressedNumber)
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
}