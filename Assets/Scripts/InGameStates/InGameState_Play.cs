using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameState_Play : InGameState
{
    public override void enterState(GameplaySceneManager gpsm, InGameState previousState = null)
    {
        Debug.Log("Entered (in-game) Play state.");
    }

    public override void doUpdate(GameplaySceneManager gpsm)
    {
        if(gpsm.pauseButtonPressed)
        {
            gpsm.pauseButtonPressed = false;
            changeState(gpsm.inGameState_Pause, gpsm);
        }
    }

}
