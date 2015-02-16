using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Tab : MonoBehaviour {
	protected GameObject displayToShow;


	void Awake() {
		
	}

	void Start() {

	}

	void Update() {

	}

	public abstract ITabDisplayInterface getEnablingScript();

	public virtual void enableDisplay() {
		getEnablingScript().enableDisplay();
	}

	public void disableDisplay() {
		getEnablingScript().disableDisplay();
	}
}