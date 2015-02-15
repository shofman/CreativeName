using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class TroopTab : Tab {
	public GameObject troopDisplay;

	public override ITabDisplayInterface getEnablingScript() {
	 	return troopDisplay.GetComponent<TroopDisplay>();
	}

	public GameObject getDisplay() {
		return troopDisplay;
	}
}