using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GroundTile : Tile 
{
    public override void Activate (string item)
    {
        // GroundTile states: 
        // "initial", "tilled", "tilled_watered", "seeded", "seeded_watered"
        switch (state) {
            case "initial": 
                // Nothing but tilling to do on fresh ground
                if (item == "hoe") 
                {
                    Debug.Log("Time to till");
                    state = "tilled";
                }
                break;
        
            case "tilled": 
                if (item == "watering can") 
                {
                    Debug.Log("Watering the tilled ground");
                    state = "tilled_watered";
                } 
                else if (item == "seeds") 
                {
                    Debug.Log("Planting tilled ground");
                    state = "seeded";
                }
                break;

            case "tilled_watered":
                // Can only seed this ground
                if (item == "seeds")
                {
                    Debug.Log("Planting tilled ground");
                    state = "seeded_watered";
                }
                break;

            case "seeded":
                if (item == "watering can")
                {
                    Debug.Log("Watering the seeds");
                    state = "seeded_watered";
                }
                break;
        }
    
        // After changing state, trigger state change event
        // TODO: actually use events not methods....
        StateChangeEvent();
    }
}
