using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShipDisplay : Display {
	public void createShipFromButton() {
		if (getPlanet() != null) {
			getPlanet().GetComponent<PlanetProduction>().createShip();
		}
	}

	public void displayShipsOnPlanet() {
		if (getPlanet() != null) {
			GameObject fleet = getPlanet().GetComponent<Planet>().getFleetOverPlanet();
			if (fleet != null) {
				fleet.GetComponent<Fleet>().listShipsInFleet();	
			}
		}
	}
}
