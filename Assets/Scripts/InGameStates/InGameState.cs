using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This is to be used purely while the overall gamestate is in Gameplay.
 * This should be subclassed to define the behavior for each state that can be entered while in gameplay.
 * e.g. Something like Pause menu, inventory menu, map screen, etc. */
public class InGameState 
{
    //Returning null should indicate that the state change was not allowed/accepted
    public virtual InGameState changeState(InGameState newState, GameplaySceneManager gpsm)
    {
        this.exitState(gpsm);
        gpsm.currentState = newState;
        newState.enterState(gpsm, this);
        return newState;
    }

    //Also acts as init method
    public virtual void enterState(GameplaySceneManager gpsm, InGameState previousState = null) { }
    public virtual void doUpdate(GameplaySceneManager gpsm) { }
    public virtual void doFixedUpdate(GameplaySceneManager gpsm) { }
    public virtual void exitState(GameplaySceneManager gpsm, InGameState nextState = null) { }
}
