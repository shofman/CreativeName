using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/**
 * Class that 
 */
public class MouseState {
	/**
	 * List of states that a mouse can be in
	 */
	public enum State {
		Default,
		MoveShip
	};

	/**
	 * The current state of the mouse
	 */
	private State currentState;

	/**
	 * Singleton pattern - we want only one instance of a mouse state per game
	 */
	private static MouseState _instance;

	/**
	 * Statically access the current mouse state
	 * @return MouseState - the current object (if initially null, we create a new MouseState)
	 */
	public static MouseState instance() {
		if (_instance == null) {
			_instance = new MouseState();
		}
		return _instance;
	}

	/**
	 * Constructor - set to private to prevent accidently use
	 */
	private MouseState() {
		currentState = State.Default;
	}

	/**
	 * Gets the curremt state of the mouse
	 * @return State - What State the mouse is in
	 */
	public State getCurrentMouseState() {
		return currentState;
	}

	/**
	 * Sets the current mouse state
	 * @param {[type]} State s - The state that we wish to set the mouse to
	 */
	public void setCurrentMouseState(State s) {
		currentState = s;
	}
}