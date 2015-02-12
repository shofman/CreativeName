using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlanetDisplay : MonoBehaviour {
	Text txt;
	GameObject planet;

	void Awake() {
		txt = gameObject.GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void createShipFromButton() {
		if (this.planet != null) {
			planet.GetComponent<PlanetProduction>().createShip();
		}
	}

	public void displayShipsOnPlanet() {
		if (this.planet != null) {
			GameObject fleet = this.planet.GetComponent<Planet>().getFleetOverPlanet();
			if (fleet != null) {
				fleet.GetComponent<Fleet>().listShipsInFleet();	
			}
		}
	}

	public void setPlanet(GameObject planet) {
		this.planet = planet;
	}

	public void setName(string name) {
		txt.text = "Planet Name: " + name;
	}

	public void setGarrisons(int garrisons) {
		txt.text = "Garrisons: " + garrisons;
	}
}
