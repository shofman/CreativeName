using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class PeopleTab : Tab {
	public GameObject peopleDisplay;

	public override ITabDisplayInterface getEnablingScript() {
	 	return peopleDisplay.GetComponent<PeopleDisplay>();
	}

	public GameObject getDisplay() {
		return peopleDisplay;
	}
}