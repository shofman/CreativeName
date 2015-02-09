using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Ship : MonoBehaviour {
	public int health = 10;
	public int shields = 1;
	public string shipName = "";

	void Awake() {

	}

	void Start() {

	}

	void Update() {

	}

	/**
	 * Sets the name of this ship
	 */
	public void setName(string name) {
		this.shipName = name;
	}

	/**
	 * Returns the name of the ship
	 * @return String - name of ship
	 */
	public string getName() {
		return shipName;
	}
}