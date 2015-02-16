using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/**
 * Generic class holding the logic shared between display panels on the planet menu
 */
public class Display : MonoBehaviour, ITabDisplayInterface {
	/**
	 * The planet we are currently viewing
	 */
	GameObject planetToDisplay;

	void Awake() {
		planetToDisplay = null;
	}

	/**
	 * Sets the planet for the menu to display
	 * @param {[type]} GameObject planet The planet we want to display
	 */
	public void setPlanet(GameObject planet) {
		planetToDisplay = planet;
	}

	/**
	 * Returns the planet we are currently displaying
	 * @return {[type]} GameObject - The planet we are viewing
	 */
	public GameObject getPlanet() {
		return planetToDisplay;
	}

	/**
	 * Enables the current display
	 */
	public void enableDisplay() {
		gameObject.SetActive(true);
	}

	/**
	 * Disables the current display
	 */
	public void disableDisplay() {
		gameObject.SetActive(false);
	}
}
