using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShipTab : Tab {
	public GameObject shipTabDisplay2;

	public override ITabDisplayInterface getEnablingScript() {
	 	return shipTabDisplay2.GetComponent<ShipDisplay>();
	}

	public GameObject getDisplay() {
		return shipTabDisplay2;
	}
}