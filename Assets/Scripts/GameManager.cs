using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Component player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent("Player") as Component;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))  {
            // pressed X
            Debug.Log("Pressed E");
        }
    }
}
