using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlanetDisplay : MonoBehaviour {
	Text txt;
	
	void Awake() {
		txt = gameObject.GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setText(string name) {
		txt.text = "Planet Name: " + name;
	}
}
