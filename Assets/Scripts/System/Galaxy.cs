using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class Galaxy : MonoBehaviour, IBreadthFirstSearchInterface {
	public GameObject planet;
	public int planetRows;
	public int planetColumns;

	public const string TRADE_ROUTE_HOLDER = "TradeRouterHolder"; 

	GameObject[,] listOfPlanets;
	GameObject planetsHolder;
	GameObject tradeRouteHolder;
	List<string> planetNames;
	System.Random random;

	List<GameObject> connectedGalaxies;

	bool hasVisited = false;
	public string galaxyName = "SAMPLE";
	int universePositionX = -1;
	int universePositionY = -1;

	public int blueUnits = 20;
	public int redUnits = 20;

	

	void Awake() {
		planetsHolder = createEmptyGameObject("PlanetsHolder");
		tradeRouteHolder = createEmptyGameObject(TRADE_ROUTE_HOLDER);
		random = new System.Random();
		connectedGalaxies = new List<GameObject>();
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

	public void createGalaxy(List<string> newPlanetNames) {
		planetNames = newPlanetNames;

		// Set galaxy name
		galaxyName = planetNames[0];
		planetNames.RemoveAt(0);

		listOfPlanets = new GameObject[planetColumns,planetRows];

		int totalBluePlanets = planetRows*planetColumns/2;
		int totalRedPlanets = totalBluePlanets;
		
		for (int i=0; i<planetRows*planetColumns; i++) {
			GameObject planetCreated = (GameObject)Instantiate(planet);
			planetCreated.transform.parent = planetsHolder.transform;
			int xPos = ((i/planetRows)*20)-20 + (int) gameObject.transform.position.x;
			int yPos = ((i%planetRows)*20)-20 + (int) gameObject.transform.position.y;
			planetCreated.GetComponent<Planet>().setPosition(xPos, yPos);
			
			planetCreated.GetComponent<Planet>().setName(planetNames[i]);
			planetCreated.GetComponent<Planet>().setIndex(i/planetRows, i%planetRows);
			listOfPlanets[i/planetRows,i%planetRows] = planetCreated;

			if (totalBluePlanets > 0 && totalRedPlanets > 0) {
				int randomValue = random.Next(0,100);
				if (randomValue < 50) {
					planetCreated.GetComponent<Planet>().changeColorAndSetUnits(Color.blue, 2);
					totalBluePlanets--;
				} else {
					planetCreated.GetComponent<Planet>().changeColorAndSetUnits(Color.red, 2);
					totalRedPlanets--;
				}
			} else if (totalBluePlanets > 0) {
				planetCreated.GetComponent<Planet>().changeColorAndSetUnits(Color.blue, 2);
				totalBluePlanets--;
			} else if (totalRedPlanets > 0) {
				planetCreated.GetComponent<Planet>().changeColorAndSetUnits(Color.red, 2);
				totalRedPlanets--;
			}
		}
		connectAllPlanets();
		removeConnections();
		for (int i=0; i<listOfPlanets.GetLength(0); i++) {
			for (int j=0; j<listOfPlanets.GetLength(1); j++) {
				removeEdgelessPlanets(listOfPlanets[i,j]);
			}
		}
		displayConnectedPlanets();
	}

	// Use this for initialization
	void Start () {
	}

	bool addAdjacentConnection(int xAdjust, int yAdjust) {
		bool added = false;
		for (int i=-1; i<2; i++) {
			for (int j=-1; j<2; j++) {
				if (j+xAdjust < planetColumns && j+xAdjust >= 0) {
					if (i+yAdjust <planetRows && i+yAdjust >= 0) {
						if (listOfPlanets[j+xAdjust,i+yAdjust].GetComponent<Planet>().hasBeenVisited() && !added) {
							addPlanet(listOfPlanets[j+xAdjust,i+yAdjust], listOfPlanets[xAdjust,yAdjust]);
							added = true;
						}
					}
				}
			}
		}
		return added;
	}

	public char mapName(int count) {
		return (char) (count + 65);
	}

	void connectAllPlanets() {
		for (int i=0; i<planetRows; i++) {
			for (int j=0; j<planetColumns; j++) {
				if (j+1 < planetColumns) {
					addPlanet(listOfPlanets[j,i], listOfPlanets[j+1,i]);
				}
				if (i+1 < planetRows) {
					for (int k=-1; k<2; k++) {
						if (j+k > -1 && j+k < planetColumns) {
							addPlanet(listOfPlanets[j+k,i+1], listOfPlanets[j,i]);
						}
					}
				}
			}
		}
	}

	void removeConnections() {
		for (int i=0; i<planetRows; i++) {
			for (int j=0; j<planetColumns; j++) {
				List<GameObject> connectedPlanets = new List<GameObject>(listOfPlanets[j,i].GetComponent<Planet>().getConnectedObjects());
				foreach (GameObject planet in connectedPlanets) {
					int randomValue = random.Next(0,100);
					if (randomValue < 70) {
						//Remove the planet from the connections for the current planet
						//Find the removed planet in our galaxy list, and remove the current planet from it
						listOfPlanets[j,i].GetComponent<Planet>().removeConnectedPlanet(planet);
						for (int x=0; x<planetRows; x++) {
							for (int y=0; y<planetColumns; y++) {
								if (listOfPlanets[y,x].GetComponent<Planet>().getName() == planet.GetComponent<Planet>().getName()) {
									listOfPlanets[y,x].GetComponent<Planet>().removeConnectedPlanet(listOfPlanets[j,i]);
								}
							}
						}

						//Check to see if we are still connected
						gameObject.GetComponent<BreadthFirstSearch>().breadthFirstSearchPlanets<Planet>(listOfPlanets[j,i], listOfPlanets, false);

						for (int a=0; a<listOfPlanets.GetLength(0); a++) {
							for (int b=0; b<listOfPlanets.GetLength(1); b++) {
								if (!listOfPlanets[a,b].GetComponent<Planet>().hasBeenRemoved() && !listOfPlanets[a,b].GetComponent<Planet>().hasBeenVisited()) {
									//The planet is still there, and hasn't been visited, so we've broken the chain. Readd the planets
									listOfPlanets[j,i].GetComponent<Planet>().addTradeRoute(planet);
									for (int x=0; x<planetRows; x++) {
										for (int y=0; y<planetColumns; y++) {
											if (listOfPlanets[y,x].GetComponent<Planet>().getName() == planet.GetComponent<Planet>().getName()) {
												listOfPlanets[y,x].GetComponent<Planet>().addTradeRoute(listOfPlanets[j,i]);
											}
										}
									}
								}
							}
						}

						//Remove planets whose edges we've removed all of
						for (int x=0; x<listOfPlanets.GetLength(0); x++) {
							for (int y=0; y<listOfPlanets.GetLength(1); y++) {
								removeEdgelessPlanets(listOfPlanets[x,y]);
							}
						}
					}
				}
			}
		}
	}

	//Connect the planets together via trade routes
	void connectPlanets() {
		for (int i=0; i<planetRows; i++) {
			for (int j=0; j<planetColumns; j++) {
				//DIAGRAM TIME
				// 0 0 0 -> x is the node to check
				// 0 x y -> y are the nodes we are joining to
				// y y y -> 0 are the nodes we skip (because they have already joined)
				if (j+1 < planetColumns) {
					int randomValue = random.Next(0,100);
					if (randomValue < 0) {
						addPlanet(listOfPlanets[j,i], listOfPlanets[j+1,i]);
					}
				}
				if (i+1 < planetRows) {
					// for (int k=-1; k<2; k++) {
					for (int k=0; k<1; k++) {
						if (j+k > -1 && j+k < planetColumns) {
							int lowerRandomValue = random.Next(0,100);
							if (j == 0 || j == 2) {
							// if (lowerRandomValue < 25) {
								addPlanet(listOfPlanets[j+k,i+1], listOfPlanets[j,i]);
							}
						}
					}
				}
				
			}
		}
	}

	void removeEdgelessPlanets(GameObject planet) {
		List<GameObject> connectedPlanets = new List<GameObject>(planet.GetComponent<Planet>().getConnectedObjects());
		if (connectedPlanets.Count == 0) {
			int xPos = planet.GetComponent<Planet>().getIndexForX();
			int yPos = planet.GetComponent<Planet>().getIndexForY();
			listOfPlanets[xPos,yPos].GetComponent<Planet>().setRemoval();
			Destroy(planet);
		}
	}

	void displayConnectedPlanets() {
		for (int i=0; i<planetRows; i++) {
			for (int j=0; j<planetColumns; j++) {
				listOfPlanets[j,i].GetComponent<Planet>().displayTradeRoutes(tradeRouteHolder);
			}
		}
	}

	void addPlanet(GameObject planetToAdd, GameObject addedPlanet) {
		Planet planetScript = planetToAdd.GetComponent<Planet>();
		planetScript.addTradeRoute(addedPlanet);
		Planet addedPlanetScript = addedPlanet.GetComponent<Planet>();
		addedPlanetScript.addTradeRoute(planetToAdd);
	}

	void displayPlanetList(List<GameObject> listToDisplay) {
		foreach (GameObject g in listToDisplay) {
			Debug.Log(g.GetComponent<Planet>().getName());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("a")) {
			gameObject.GetComponent<BreadthFirstSearch>().breadthFirstSearchPlanets<Planet>(listOfPlanets[2,2], listOfPlanets, true);
		}
	}

	public void addGalacticRoute(GameObject galaxy) {
		this.connectedGalaxies.Add(galaxy);
	}

	// Breadth first search
	public bool hasBeenVisited() {
		return hasVisited;
	}
	public void setVisited(bool visited) {
		hasVisited = visited;
	}
	public void setIndex(int xPos, int yPos) {
		universePositionX = xPos;
		universePositionY = yPos;
	}
	public int getIndexForX() {
		return universePositionX;
	}
	public int getIndexForY() {
		return universePositionY;
	}
	public string getName() {
		return galaxyName;
	}
	public List<GameObject> getConnectedObjects() {
		return this.connectedGalaxies;
	}

}
