using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GalaxyDisplay : MonoBehaviour {
	//The distance at which we should show the galaxy overlay (the name floating atop the galaxy)
	public int displayHeight = -200;

	// The camera whose position we rely on to determine the current distance
	public GameObject mainCamera;

	// List of all the galaxies overlays that we want to toggle
	private List<GameObject> listOfGalaxyDisplays;

	// Whether or not we are far enough away to show the galaxy state or not
	private bool showingGalaxyNames = false;

	// Initialization
	void Awake() {
		listOfGalaxyDisplays = new List<GameObject>();
	}

	void Start() {
		
	}

	/**
	 * Check to see if we should hide or show the galaxy overlay (depending on the distance)
	 */
	void Update() {
		if (mainCamera.transform.position.z < displayHeight) {
			showGalaxyNames();
		} else {
			hideGalaxyNames();
		}
	}

	/**
	 * Show the galaxy overlay (only if we are currently hiding it)
	 */
	void showGalaxyNames() {
		if (!showingGalaxyNames) {
			showingGalaxyNames = true;
			changeDisplayState(true);
		}
	}

	/**
	 * Hide the galaxy overlay (only if we are currently showing it)
	 */
	void hideGalaxyNames() {
		if (showingGalaxyNames) {
			showingGalaxyNames = false;
			changeDisplayState(false);
		}
	}

	/**
	 * Sets whether we are displaying the galaxy UI overlay or not
	 * @param  active - whether or not we are displaying the overlay
	 */
	void changeDisplayState(bool active) {
		foreach (GameObject game in listOfGalaxyDisplays) {
			game.SetActive(active);
		}
	}

	/**
	 * Add a galaxy overlay UI gameobject to the list of toggable states
	 * @param The galaxy overlay game object we want to add
	 * @param The name that it should display when visible
	 */
	public void addGalaxyDisplay(GameObject galaxyDisplay, string name) {
		listOfGalaxyDisplays.Add(galaxyDisplay);
		GameObject test = galaxyDisplay.transform.Find("GalaxyNameDisplay").gameObject;
		test.GetComponent<Text>().text = name;
	}
}