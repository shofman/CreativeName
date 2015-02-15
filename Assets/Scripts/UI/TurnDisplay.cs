using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TurnDisplay : MonoBehaviour {
	Text txt;
	int turnCount = 0;

	void Awake() {
		txt = gameObject.GetComponent<Text>();
		updateCount();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	/**
	 * Increments the turn count 
	 */
	public void updateCount() {
		turnCount++;
		txt.text = "Turn: " + turnCount;
	}
}
