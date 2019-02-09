using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenState : GameState
{
    public override void enterState(GameController gc, GameState previousState = null)
    {
        Debug.Log("Entered TitleScreen state.");
    }

    public override void doUpdate(GameController gc)
    {
        if(gc.newGamePressed) {
            gc.newGamePressed = false;
            gc.nextStateOnLoaded = gc.GameplayState;
            changeState(gc.LoadingState, gc);
            SceneManager.LoadScene("Gameplay");
        }
    }
}
