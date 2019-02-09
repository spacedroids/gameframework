using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameState_Pause : InGameState
{
    public override void enterState(GameplaySceneManager gpsm, InGameState previousState = null)
    {
        Debug.Log("Entered (in-game) Pause state.");

        //Freeze time
        Time.timeScale = 0;

        //Activate pause menu canvas
        gpsm.pauseCanvas.SetActive(true);

        //For extra safety, should init any flags this state depends on
        gpsm.quitButtonPressed = false;
        gpsm.unPauseButtonPressed = false;
    }

    public override void doUpdate(GameplaySceneManager gpsm)
    {
        if(gpsm.unPauseButtonPressed) {
            gpsm.unPauseButtonPressed = false;
            changeState(gpsm.inGameState_Play, gpsm);
        }
    }

    public override void exitState(GameplaySceneManager gpsm, InGameState nextState = null)
    {
        //Unfreeze time to resume gameplay
        Time.timeScale = 1;

        //Hide the pause menu
        gpsm.pauseCanvas.SetActive(false);
    }
}
