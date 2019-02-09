using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameState_Play : InGameState
{
    public override void enterState(GameplaySceneManager gpsm, InGameState previousState = null)
    {
        Debug.Log("Entered (in-game) Play state.");

        //Should make sure pause menu is hidden on init
        gpsm.pauseCanvas.SetActive(false);
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
