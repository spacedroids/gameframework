
//https://unity3d.com/learn/tutorials/modules/intermediate/scripting/delegates
//http://www.codeproject.com/Articles/509234/The-State-Design-Pattern-vs-State-Machine

/// <summary>
/// This represents the superclass for the game's state. This should be stored
/// in the gamecontroller. Each state subclass will have specific instructions
/// on how and when to transition to other states.
/// 
/// These are implemented as singletons and therefore should have no local variables.
/// One instance of each of these states is shared between all instantiated gamecontrollers.
/// </summary>
public class GameState {
	//Returning null should indicate that the state change was not allowed/accepted
	public virtual GameState changeState(GameState newState, GameController gamecontroller) {
		this.exitState(gamecontroller);
		gamecontroller.currentState = newState;
		newState.enterState(gamecontroller, this);
		return newState;
	}
	
	//Also acts as init method
	public virtual void enterState(GameController gamecontroller, GameState previousState=null) {}
	public virtual void doUpdate(GameController gamecontroller) {}
	public virtual void doFixedUpdate(GameController gamecontroller) {}
	public virtual void exitState(GameController gamecontroller, GameState nextState=null) {}
}
