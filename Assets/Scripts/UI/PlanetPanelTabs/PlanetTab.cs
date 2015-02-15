using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlanetTab : Tab {
	public GameObject planetDisplay;

	public override ITabDisplayInterface getEnablingScript() {
	 	return planetDisplay.GetComponent<PlanetDisplay>();
	}

	public GameObject getDisplay() {
		return planetDisplay;
	}
}