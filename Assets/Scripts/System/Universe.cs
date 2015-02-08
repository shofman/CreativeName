using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class Universe : MonoBehaviour {
	public GameObject galaxy;
	public int numberOfGalaxies;

	GameObject[,] listOfGalaxies;
	System.Random random;
	Queue<string> availableNames;

	void Awake() {
		// 5000 seems to be alright
		NameGenerator nameGenerator = new NameGenerator(numberOfGalaxies * 22);
		availableNames = nameGenerator.generatePlanetNamesAsQueue();
	}

	GameObject createEmptyGameObject(string name) {
		GameObject generic = null;
		bool found = false;

		Transform[] transforms = this.GetComponentsInChildren<Transform>();
		foreach (Transform t in transforms) {
			if (t.gameObject.name == name) {
				generic = t.gameObject;
				found = true;
				break;
			}
		}
		if (!found) {
			generic = new GameObject(name);
			generic.transform.parent = this.transform;
		}
		return generic;
	}

	// Use this for initialization
	void Start () {
		listOfGalaxies = new GameObject[numberOfGalaxies,1];

		for (int i=0; i<listOfGalaxies.GetLength(0); i++) {
			GameObject galaxyCreated = (GameObject)Instantiate(galaxy);
			galaxyCreated.transform.Translate(i*120, 0, 0);
			Galaxy galaxyScript = galaxyCreated.GetComponent<Galaxy>();

			// Each planet needs a name, plus the galaxy should be named
			int totalNamesNeeded = (galaxyScript.planetRows * galaxyScript.planetColumns) + 1;
			galaxyScript.setIndex(i, 0);
			// Transfer over the total needed amount to a new list
			List<string> galaxyNames = new List<string>();
			for (int j=0; j<totalNamesNeeded; j++) {
				galaxyNames.Add(availableNames.Dequeue());
			}

			galaxyScript.createGalaxy(galaxyNames);
			listOfGalaxies[i,0] = galaxyCreated;

		}
		connectGalaxies();
	}

	void connectGalaxies() {
		for (int i=1; i<listOfGalaxies.GetLength(0); i++) {
			addGalaxy(listOfGalaxies[i,0], listOfGalaxies[i-1,0]);
		}
	}

	void addGalaxy(GameObject galaxyToAdd, GameObject addedGalaxy) {
		galaxyToAdd.GetComponent<Galaxy>().addGalacticRoute(addedGalaxy);
		addedGalaxy.GetComponent<Galaxy>().addGalacticRoute(galaxyToAdd);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("b")) {
			gameObject.GetComponent<BreadthFirstSearch>().breadthFirstSearchPlanets<Galaxy>(listOfGalaxies[2,0], listOfGalaxies, true);
		}
	}
}
