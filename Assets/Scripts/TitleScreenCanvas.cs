using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenCanvas : MonoBehaviour
{
    public void startNewGame()
    {
        GameController.Instance.gotoGameplay();
    }
}
