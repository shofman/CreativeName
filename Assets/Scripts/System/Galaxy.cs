using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;


public class Galaxy : MonoBehaviour, IBreadthFirstSearchInterface {
	// The planet object
	public GameObject planet;

	//UI element that will display the name of the galaxy
	public GameObject galaxyNameUI;

	//Number of planets in terms of rows and columns
	public int planetRows;
	public int planetColumns;

	//Name of the object that houses the trade routes for this galaxy
	public const string TRADE_ROUTE_HOLDER = "TradeRouterHolder"; 

	// List of planets within this galaxy
	GameObject[,] listOfPlanets;

	// Empty game object to hold collections of gameobjects
	GameObject planetsHolder;
	GameObject tradeRouteHolder;

	// List of potential planet names for this galaxy
	List<string> planetNames;

	// Random number generator
	System.Random random;

	// List of all connected galaxies to this particular galaxy
	List<GameObject> connectedGalaxies;

	// Whether we have visited this galaxy before (for searches)
	bool hasVisited = false;

	// The name of this galaxy
	public string galaxyName = "";

	//Initial position in global array holding position
	int universePositionX = -1;
	int universePositionY = -1;

	// Total number of units used per galaxy
	public int blueUnits = 20;
	public int redUnits = 20;

	
	/**
	 * On intialization, create necessary child gameobjects, setup random generator, and initialize required variables
	 */
	void Awake() {
		planetsHolder = createEmptyGameObject("PlanetsHolder");
		tradeRouteHolder = createEmptyGameObject(TRADE_ROUTE_HOLDER);
		random = new System.Random();
		connectedGalaxies = new List<GameObject>();
	}

	/**
	 * Finds a game object of the children with a particular name, or creates it
	 * @param name - The name of the parent gameobject we are wanting to find the game object
	 * @return GameObject - created or found game object with the given name
	 */
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

	/**
	 * Responsible for setting up and creating the planets in a particular galaxy
	 *     * Will position them in grid
	 *     * Sets colors to either red or blue
	 *     * Creates random connected graph based on available nodes
	 * @param newPlanetNames - List of randomly generated planet names
	 */
	public void createGalaxy(List<string> newPlanetNames) {
		planetNames = newPlanetNames;

		// Set galaxy name first, and remove it from list (no duplicates)
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

	/**
	 * Create the UI display for the particular galaxy 
	 * @param  GameObject - The canvas that houses the UI elements for displaying the galaxy info
	 */
	public void createGalaxyUIElements(GameObject canvasDisplay) {
		GameObject galaxyUI = (GameObject) Instantiate(galaxyNameUI);
		galaxyUI.transform.SetParent(canvasDisplay.transform, false);
		galaxyUI.transform.Translate(gameObject.transform.position.x, gameObject.transform.position.y, 0);
		galaxyUI.SetActive(false);
		canvasDisplay.GetComponent<GalaxyDisplay>().addGalaxyDisplay(galaxyUI, getName());
	}

	// Use this for initialization
	void Start () {
	}

	/**
	 * Connects every planet within a galaxy to its neighbors
	 */
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

	/**
	 * Randomly remove the trade routes between planets
	 */
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

	/**
	 * Removes all planets that do not have any trade routes leading to them
	 * @param  GameObject planet - the current planet we are investigating
	 */
	void removeEdgelessPlanets(GameObject planet) {
		List<GameObject> connectedPlanets = new List<GameObject>(planet.GetComponent<Planet>().getConnectedObjects());
		if (connectedPlanets.Count == 0) {
			int xPos = planet.GetComponent<Planet>().getIndexForX();
			int yPos = planet.GetComponent<Planet>().getIndexForY();
			listOfPlanets[xPos,yPos].GetComponent<Planet>().setRemoval();
			Destroy(planet);
		}
	}

	/**
	 * Display the connections between the planets as line renderers
	 */
	void displayConnectedPlanets() {
		for (int i=0; i<planetRows; i++) {
			for (int j=0; j<planetColumns; j++) {
				listOfPlanets[j,i].GetComponent<Planet>().displayTradeRoutes(tradeRouteHolder);
			}
		}
	}

	/**
	 * Add the planetary connection between the two planets at the planet level (two-way link)
	 * @param The first planet we are connecting to 
	 * @param The second planet we are connecting to
	 */
	void addPlanet(GameObject planetToAdd, GameObject addedPlanet) {
		Planet planetScript = planetToAdd.GetComponent<Planet>();
		planetScript.addTradeRoute(addedPlanet);
		Planet addedPlanetScript = addedPlanet.GetComponent<Planet>();
		addedPlanetScript.addTradeRoute(planetToAdd);
	}

	/**
	 * Display the planet names within a galaxy
	 * @param  The list of planets we want to display
	 */
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

	/**
	 * Add which galaxies this particular galaxy is connected to
	 * @param GameObject galaxy - the galaxy we want to connect this to
	 */
	public void addGalacticRoute(GameObject galaxy) {
		this.connectedGalaxies.Add(galaxy);
	}

	// BREADTH FIRST SEARCH VARIABLES
	/**
	 * Whether or not we have been visited during a breadth first search
	 * @return If we have already visited this galaxy during a search
	 */
	public bool hasBeenVisited() {
		return hasVisited;
	}

	/**
	 * Sets whether we have visited the planet or not
	 * @param bool visited - whether we have visited the galaxy before
	 */
	public void setVisited(bool visited) {
		hasVisited = visited;
	}

	/**
	 * Sets the indices within the parent array (in this case, universe) for easy access during search
	 * @param int xPos - The first parameter in the two dimensional array this value is stored within in the parent array
	 * @param int yPos - The second parameter in the two dimensional array this value is stored within in the parent array
	 */
	public void setIndex(int xPos, int yPos) {
		universePositionX = xPos;
		universePositionY = yPos;
	}

	/**
	 * Returns the first index for accessing this value in the storage two-dimensional array in the parent
	 * @return int - the position this value is in within the parent array
	 */
	public int getIndexForX() {
		return universePositionX;
	}

	/**
	 * Returns the second index for accessing this value in the storage two-dimensional array in the parent
	 * @return int - the position this value is in within the parent array
	 */
	public int getIndexForY() {
		return universePositionY;
	}

	/**
	 * Returns the name of this galaxy
	 * @return string 
	 */
	public string getName() {
		return galaxyName;
	}

	/**
	 * Returns the number of galaxies this function is connected to 
	 * @return List<GameObject> a list of all connected galaxies to this galaxy
	 */
	public List<GameObject> getConnectedObjects() {
		return this.connectedGalaxies;
	}

}
