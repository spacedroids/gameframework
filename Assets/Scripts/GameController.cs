using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * The game model.
 * Holds the current state, but operates without needing to know what the state is.
 * Knows what level/scene is loaded and informs the current state.
 * Holds references to critical items like player object
 */
public class GameController : MonoSingleton<GameController> {

	//The current gamestate, e.g. main menu, gameplay, paused, etc.
	//Shouldn't be directly modified, except by GameState subclasses.
	public GameState currentState;

	public GameState TitleScreenState;
	public GameState GameplayState;
	public GameState LoadingState;

	public GameState nextStateOnLoaded;

	//Storage manager for all reads/writes of data that needs to persist between game sessions.
	//public DataStore storage;

	//Navigation/Event Flags
	public bool newGamePressed;

	//Instantiate each of the state subclasses. We want to do this once and keep the same copy, every state change just reuses the object.
	private void InstantiateStateClasses(){
        TitleScreenState = new TitleScreenState();
        GameplayState = new GameplayState();
        LoadingState = new LoadingState();
	}

	protected override void Awake() {
		//Base 'MonoSingleton' class will setup this object as `DontDestroyOnLoad`
		base.Awake();
	}

	void Start() {
		Application.targetFrameRate = 60;
		InstantiateStateClasses();
		//If curretState is null, then we're in a pre-initialized state
		if(currentState == null) {
            //This looks up the scene filename and maps it to a game state.
			string lvlname = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
			if(lvlname == "Gameplay") {
				currentState = GameplayState;
			} else if(lvlname == "TitleScreen") {
				currentState = TitleScreenState;
			} else {
				Debug.LogError("Could not find a matching game state to start in for the scene " + lvlname);
			}
			currentState.enterState(this);
		}
	}

    void Update()
    {
        if(currentState != null)
        {
            currentState.doUpdate(this);
        }
    }

    void FixedUpdate()
    {
        if(currentState != null)
        {
            currentState.doFixedUpdate(this);
        }
    }

}