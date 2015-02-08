using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class Universe : MonoBehaviour {
	public GameObject galaxy;
	public int numberOfGalaxies;

	GameObject[] listOfGalaxies;
	System.Random random;
	Queue<string> availableNames;

	void Awake() {
		NameGenerator nameGenerator = new NameGenerator(5000);
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
		listOfGalaxies = new GameObject[numberOfGalaxies];

		for (int i=0; i<listOfGalaxies.Length; i++) {
			GameObject galaxyCreated = (GameObject)Instantiate(galaxy);
			galaxyCreated.transform.Translate(i*120, 0, 0);
			Galaxy galaxyScript = galaxyCreated.GetComponent<Galaxy>();

			// Each planet needs a name, plus the galaxy should be named
			int totalNamesNeeded = (galaxyScript.planetRows * galaxyScript.planetColumns) + 1;
			
			// Transfer over the total needed amount to a new list
			List<string> galaxyNames = new List<string>();
			for (int j=0; j<totalNamesNeeded; j++) {
				galaxyNames.Add(availableNames.Dequeue());
			}

			galaxyScript.createGalaxy(galaxyNames);
			// galaxyCreated.transform.parent = planetsHolder.transform;
			// galaxyCreated.GetComponent<Planet>().setPosition(((i/planetRows)*20)-20, ((i%planetRows)*20)-20);
			
			// galaxyCreated.GetComponent<Galaxy>().createGalaxy();
			listOfGalaxies[i] = galaxyCreated;

		}
		connectGalaxies();
	}

	void connectGalaxies() {

	}

	void addPlanet(GameObject planetToAdd, GameObject addedPlanet) {
		Planet planetScript = planetToAdd.GetComponent<Planet>();
		planetScript.addTradeRoute(addedPlanet);
		Planet addedPlanetScript = addedPlanet.GetComponent<Planet>();
		addedPlanetScript.addTradeRoute(planetToAdd);
	}

	void breadFirstSearchGalaxies(GameObject initialNode) {
		Queue searchQueue = new Queue();
		searchQueue.Enqueue(initialNode);

		while (searchQueue.Count != 0) {
			GameObject currPlanet = (GameObject) searchQueue.Dequeue();
			string name = currPlanet.GetComponent<Planet>().getName();
			//find the current index, use it to find the corresponding planet in the array, and set its visited status to true
			int xPos = currPlanet.GetComponent<Planet>().getIndexForX();
			int yPos = currPlanet.GetComponent<Planet>().getIndexForY();
			// listOfPlanets[xPos,yPos].GetComponent<Planet>().setVisited(true);

			List<GameObject> connectedPlanets = new List<GameObject>(currPlanet.GetComponent<Planet>().getConnectedPlanets());
			// displayPlanetList(connectedPlanets);
			for (int i=0; i<connectedPlanets.Count; i++) {
				int x = connectedPlanets[i].GetComponent<Planet>().getIndexForX();
				int y = connectedPlanets[i].GetComponent<Planet>().getIndexForY();
				// if (!searchQueue.Contains(connectedPlanets[i]) && !listOfPlanets[x,y].GetComponent<Planet>().hasBeenVisited()) {
				// 	searchQueue.Enqueue(connectedPlanets[i]);
				// }
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("a")) {
		}
	}
}
