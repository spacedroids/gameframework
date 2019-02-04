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

	public GameState TitleScreen;
	public GameState GameplayState;
	public GameState Loading;

	public GameState nextStateOnLoaded;

	//Storage manager for all reads/writes of data that needs to persist between game sessions.
	//public DataStore storage;

	//Navigation/Event Flags
	public bool navHomebaseRequested;
	public bool navLevelSelectRequested;
	public bool smugglerCaught;
	public bool smugglerWarped;
	public bool playerDead;
	public bool playerWarped;
	public float distanceToTarget;
	public bool navGameplayRequested;

	//Instantiate each of the state subclasses. We want to do this once and keep the same copy, every state change just reuses the object.
	private void instantiateStateClasses(){
		//TitleScreen = new TitleScreen();
		GameplayState = new GameplayState();
		//IntroToGameplay = new IntroToGameplay();
		//Homebase = new Homebase();
		//Loading = new Loading();
		//LevelSelect = new LevelSelect();
		//EngineTest = new EngineTest();
	}

	protected override void Awake() {
		//storage = new DataStore();

		//Load turret prefabs
		//emptyTurretMountPrefab = (Resources.Load("Weapons/Turrets/EmptyTurretMount") as GameObject).GetComponent<Turret>();
		//lightBoltTurretPrefab = (Resources.Load("Weapons/Turrets/LightBoltTurret") as GameObject).GetComponent<Turret>();

		//Base 'MonoSingleton' class will setup this object as `DontDestroyOnLoad`
		base.Awake();
	}

	void Start() {
		Application.targetFrameRate = 60;
		instantiateStateClasses();
		//If curretState is null, then we're in a pre-initialized state
		if(currentState == null) {
			string lvlname = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
			if(lvlname == "Gameplay") {
				currentState = GameplayState;
			} else if(lvlname == "TitleScreen") {
				currentState = TitleScreen;
			} else {
				Debug.LogError("Could not find a matching game state to start in for the scene " + lvlname);
			}
			currentState.enterState(this);
		}
	}

	void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (currentState != null) {
			if(currentState == Loading) {
				currentState.changeState(nextStateOnLoaded, this);
			}
		}
	}

	public void reset() {
		//restart = true;
	}

	public void gotoGameplay() {
		navGameplayRequested = true;
	}

	public void gotoHomebase() {
		navHomebaseRequested = true;
	}

	public void gotoLevelSelect() {
		navLevelSelectRequested = true;
	}

	public void notifySmugglerCaught() {
		smugglerCaught = true;
	}

	public void notifySmugglerWarped() {
		smugglerWarped = true;
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