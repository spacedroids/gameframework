using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayState : GameState
{
    private GameplaySceneManager gpsm;

    public override void enterState(GameController gc, GameState previousState = null)
    {
        Debug.Log("Entered Gameplay state.");
        gpsm = GameObject.Find("GameplaySceneManager").GetComponent<GameplaySceneManager>();
    }

    public override void doUpdate(GameController gc)
    {
        if(gpsm.quitButtonPressed)
        {
            gpsm.quitButtonPressed = false;
            gc.nextStateOnLoaded = gc.TitleScreenState;
            changeState(gc.LoadingState, gc);
            SceneManager.LoadScene("TitleScreen");
        }
        gpsm.currentState.doUpdate(gpsm);
    }

    public override void doFixedUpdate(GameController gc)
    {
        gpsm.currentState.doFixedUpdate(gpsm);
    }
}
