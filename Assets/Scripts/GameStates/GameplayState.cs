using UnityEngine;

public class GameplayState : GameState
{
    public override void enterState(GameController gamecontroller, GameState previousState = null)
    {
        Debug.Log("Entered gameplay state.");
    }
}
