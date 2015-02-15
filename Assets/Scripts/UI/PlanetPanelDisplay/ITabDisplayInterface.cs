using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public interface ITabDisplayInterface {
	void enableDisplay();
	void disableDisplay();
	void setPlanet(GameObject planet);
}