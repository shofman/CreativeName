using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

/**
 * Houses the logic for activating and deactivating the ship tab object
 */
public class ShipTab : Tab {
	/**
	 * The Display object that houses the information about the ships
	 */
	public GameObject shipTabDisplay;

	/**
	 * Finds the script that controls the enabling of the display panel
	 * @return ITabDisplayInterface - a display object that implements the 
	 *                                interface for enabling display panel
	 */
	public override ITabDisplayInterface getEnablingScript() {
	 	return shipTabDisplay.GetComponent<ShipDisplay>();
	}

	/**
	 * Gets the shipDisplay panel object
	 * @return GameObject Ship Display - our display panel object
	 */
	public GameObject getDisplay() {
		return shipTabDisplay;
	}

	/**
	 * Overrides the enable display of Display
	 * We want to validate if we should allow the users to move their ships
	 * If they cannot, we disable the button
	 */
	public override void enableDisplay() {
		getEnablingScript().enableDisplay();
		shipTabDisplay.GetComponent<ShipDisplay>().validateMoveShipButton();
	}
}