using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenState : GameState
{
    public override void enterState(GameController gamecontroller, GameState previousState = null)
    {
        Debug.Log("Entered TitleScreen state.");
    }

    public override void doUpdate(GameController gamecontroller)
    {
        if(gamecontroller.newGamePressed) {
            gamecontroller.newGamePressed = false;
            gamecontroller.nextStateOnLoaded = gamecontroller.GameplayState;
            changeState(gamecontroller.LoadingState, gamecontroller);
            SceneManager.LoadScene("Gameplay");
        }
    }
}
