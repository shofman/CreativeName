using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShipDisplay : Display {
	public GameObject moveShipButton;

	/**
	 * Create a single ship from a button
	 */
	public void createShipFromButton() {
		if (getPlanet() != null) {
			getPlanet().GetComponent<PlanetProduction>().createShip();
			validateMoveShipButton();
		}
	}

	/**
	 * List all the ships currently on the planet
	 */
	public void displayShipsOnPlanet() {
		if (getPlanet() != null) {
			GameObject fleet = getPlanet().GetComponent<Planet>().getFleetOverPlanet();
			if (fleet != null) {
				fleet.GetComponent<Fleet>().listShipsInFleet();	
			}
		}
	}

	/**
	 * Validates whether or not we should show the move ship button
	 * Disables it if we cannot move ships
	 */
	public void validateMoveShipButton() {
		if (getPlanet() != null) {
			if (getPlanet().GetComponent<Planet>().getFleetOverPlanet() != null) {
				moveShipButton.GetComponent<Button>().interactable = true;
			} else {
				moveShipButton.GetComponent<Button>().interactable = false;
			}
		}
	}
}
