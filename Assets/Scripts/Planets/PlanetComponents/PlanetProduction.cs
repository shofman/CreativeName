using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlanetProduction : MonoBehaviour {
	// GameObject of a fleet of ships
	public GameObject fleetObject;
	public GameObject shipObject;

	void Awake() {

	}

	void Start() {

	}

	void Update() {

	}

	/**
	 * Creates a ship
	 	* Either creates a new fleet if no ships are present, or adds the new ship to a fleet
	 *
	 * @return {[type]}
	 */
	public void createShip() {
		GameObject fleet = gameObject.GetComponent<Planet>().getFleetOverPlanet();
		if (fleet == null) {
			fleet = (GameObject) Instantiate(fleetObject);
			gameObject.GetComponent<Planet>().setFleet(fleet);
		}
		GameObject ship = (GameObject) Instantiate (shipObject);
		ship.GetComponent<Ship>().setName("HAR");
		fleet.GetComponent<Fleet>().addShipToFleet(ship);
		fleet.GetComponent<Fleet>().listShipsInFleet();
	}
}