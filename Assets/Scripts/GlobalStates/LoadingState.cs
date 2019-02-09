using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingState : GameState
{
    public override void enterState(GameController gamecontroller, GameState previousState = null)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void exitState(GameController gamecontroller, GameState nextState = null)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        changeState(GameController.Instance.nextStateOnLoaded, GameController.Instance);
    }
}
