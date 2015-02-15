using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlanetDisplay : Display {
	public GameObject planetName;

	Text txt;

	void Awake() {
		txt = planetName.GetComponent<Text>();
	}

	public void setName(string name) {
		txt.text = "Planet Name: " + name;
	}
}
