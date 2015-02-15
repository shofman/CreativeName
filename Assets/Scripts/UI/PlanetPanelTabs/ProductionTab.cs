using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class ProductionTab : Tab {
	public GameObject productionDisplay;

	public override ITabDisplayInterface getEnablingScript() {
	 	return productionDisplay.GetComponent<ProductionDisplay>();
	}

	public GameObject getDisplay() {
		return productionDisplay;
	}
}