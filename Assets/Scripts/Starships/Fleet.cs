using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Fleet : MonoBehaviour {
	List<GameObject> shipsInFleet;
	
	void Awake() {
		shipsInFleet = new List<GameObject>();
	}

	void Start() {

	}

	void Update() {

	}

	/**
	 * Adds the ship to the list of ships within this fleet
	 * @param Ship - the ship we want to add to this fleet
	 */
	public void addShipToFleet(GameObject ship) {
		shipsInFleet.Add(ship);
	}

	/**
	 * Lists off all the ships in this fleet by name
	 */
	public void listShipsInFleet() {
		foreach (GameObject ship in shipsInFleet) {
			string name = ship.GetComponent<Ship>().getName();
			Debug.Log(name);
		}
	}
}