using UnityEngine;

public class GameplayState : GameState
{
    private GameplaySceneManager gpsm;

    public override void enterState(GameController gamecontroller, GameState previousState = null)
    {
        Debug.Log("Entered Gameplay state.");
        gpsm = GameObject.Find("GameplaySceneManager").GetComponent<GameplaySceneManager>();
    }

    public override void doUpdate(GameController gamecontroller)
    {
        gpsm.currentState.doUpdate(gpsm);
    }

    public override void doFixedUpdate(GameController gamecontroller)
    {

        gpsm.currentState.doFixedUpdate(gpsm);
    }
}
