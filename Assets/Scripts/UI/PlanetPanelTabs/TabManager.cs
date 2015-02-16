using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class TabManager : MonoBehaviour {
	// GameObject of the button to turn on the ship display
	public GameObject shipTab;

	// GameObject of the button to turn on the troop display
	public GameObject troopTab;

	// GameObject of the button to turn on the planet display
	public GameObject planetTab;

	// GameObject of the button to turn on the people display
	public GameObject peopleTab;

	// GameObject of the button to turn on the resource display
	public GameObject resourceTab;

	//List of all the tabs managed by this class
	private List<GameObject> listOfTabs;

	//The color we want to set the button's pressed state to
	private Color buttonPressed;

	//The color we want to set the button's highlighted state to
	private Color buttonHighlighted;

	//The tab that is currently selected
	private GameObject currentlySelectedTab;

	//Whether or not the planet info panel is currently open
	private bool isOpen;

	void Awake() {
		// Add every tab to our list of tabs 
		listOfTabs = new List<GameObject>();
		addToTabList(shipTab);
		addToTabList(troopTab);
		addToTabList(planetTab);
		addToTabList(peopleTab);
		addToTabList(resourceTab);

		//Setup the colors to use
		buttonHighlighted = new Color(.5f, 200.0f/255.0f, .5f);
		buttonPressed = new Color(176.0f/255.0f, 216.0f/255.0f, 181.0f/255.0f);
		setupDefaultColorsForTabs();

		//Setup the listeners to listen for button clicks
		setupListeners();

		// Sets the current tab to be ship
		setCurrentlySelectedTab(shipTab);

		// The menu is not displayed on initial load
		isOpen = false;
	}

	/**
	 * Adds the game object that represents a tab button to our list of tabs
	 * @param GameObject tab The Tab with a button that we want to add
	 */
	private void addToTabList(GameObject tab) {
		if (tab != null) {
			listOfTabs.Add(tab);
		}
	}

	void Start() {

	}

	void Update() {

	}

	/**
	 * Sets the normal color for a button on a particular tab
	 * @param GameObject tab The tab we want to update
	 * @param Color      c   The color we want to update our tab to
	 */
	private void setNormalColor(GameObject tab, Color c) {
		ColorBlock colors = tab.GetComponent<Button>().colors;
		colors.normalColor = c;
		tab.GetComponent<Button>().colors = colors;
	}

	/**
	 * Sets the highlighted color for a button on a particular tab
	 * @param {[type]} GameObject tab The tab we want to update
	 * @param {[type]} Color      c   The color we want to update our tab's highlighted color to be
	 */
	private void setHighlightColor(GameObject tab, Color c) {
		ColorBlock colors = tab.GetComponent<Button>().colors;
		colors.highlightedColor = c;
		tab.GetComponent<Button>().colors = colors;
	}

	/**
	 * Sets the pressed color for a button on a particular tab
	 * @param {[type]} GameObject tab The tab we want to update 
	 * @param {[type]} Color      c   The color we want to update our tab's pressed color to be
	 */
	private void setPressedColor(GameObject tab, Color c) {
		ColorBlock colors = tab.GetComponent<Button>().colors;
		colors.pressedColor = c;
		tab.GetComponent<Button>().colors = colors;
	}

	/**
	 * Deactive the tab by setting its color to white and calling its own deactive method
	 * @param  {[type]} GameObject tab           The tab we want to deactivate
	 */
	private void deactiveTab(GameObject tab) {
		setNormalColor(tab, Color.white);
	}

	/**
	 * Set the default highlighted and pressed colors for our buttons
	 */
	private void setupDefaultColorsForTabs() {
		foreach (GameObject tab in listOfTabs) {
			setHighlightColor(tab, buttonHighlighted);
			setPressedColor(tab, buttonPressed);
		}
	}

	/**
	 * Sets the listeners for when the button is clicked to change the tab
	 */
	private void setupListeners() {
		foreach (GameObject tab in listOfTabs) {
			Button b = tab.GetComponent<Button>();
			GameObject localTab = tab;
			b.onClick.AddListener(() => setCurrentlySelectedTab(localTab));
		}
	}

	/**
	 * Goes through the list and deactivates all the tabs present. Then enable the one currently selected
	 */
	public void deactivateAllTabs() {
		foreach (GameObject tab in listOfTabs) {
			deactiveTab(tab);
			tab.GetComponent<Tab>().disableDisplay();
		}
	}

	/**
	 * When opening the menu from a closed state, we want to only show the currently selected tab
	 */
	public void enableDisplayOnOpen() {
		if (!isMenuOpen()) {
			setOpen(true);
		}
		deactivateAllTabs();
		enableCurrentlySelectedTab();

	}

	/**
	 * Sets the state of the menu (closed or open)
	 * @param {[type]} bool open - Whether the menu should be closed or open
	 */
	public void setOpen(bool open) {
		isOpen = open;
	}

	/**
	 * Returns whether the menu is open or not
	 * @return {Boolean} Is the menu open
	 */
	public bool isMenuOpen() {
		return isOpen;
	}

	/**
	 * Finds the currently selected tab
	 * @return {[type]} GameObject - The tab that we have currently selected
	 */
	private GameObject getCurrentlySelectedTab() {
		return currentlySelectedTab;
	}

	/**
	 * Sets the currently selected tab, and updates the tab options accordingly
	 * @param {[type]} GameObject tab The tab we want to be active
	 */
	private void setCurrentlySelectedTab(GameObject tab) {
		currentlySelectedTab = tab;
		enableCurrentlySelectedTab();
	}

	/**
	 * Performs the logic for enabling the currently selected tab 
	 * Sets the color of the button and enables the object within the scene
	 */
	private void enableCurrentlySelectedTab() {
		setNormalColor(currentlySelectedTab, buttonHighlighted);
		currentlySelectedTab.GetComponent<Tab>().enableDisplay();
	}
}