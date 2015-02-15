using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Planet : MonoBehaviour, IPointerClickHandler, IBreadthFirstSearchInterface {
	//Spice provides money, which buys troops every round
	//Defense provides a defense bonus, 
	//Garrisons provides the defense value, which must be beaten to determine victory
	//Trade Routes determine where a planet can connect with
	int spice;
	int defense;
	int garrisons;
	bool isRemoved = false;
	bool hasVisited = false;
	bool createdNameObject = false;
	string planetName;
	int galaxyPositionX = -1;
	int galaxyPositionY = -1;
	List<GameObject> connectedPlanets;
	List<GameObject> listOfRoutes;

	public GameObject planetNameDisplay;
	public GameObject tradeRoute;
	public float lineWidth;
	
	GameObject canvasUI;
	GameObject tabManager;
	GameObject fleetOverPlanet;

	// Displays for planet
	GameObject shipDisplay;
	GameObject troopDisplay;
	GameObject peopleDisplay;
	GameObject productionDisplay;
	GameObject planetDisplay;
	System.Random random;

	void Awake() {
		canvasUI = GameObject.Find("/PlanetMenu");
		tabManager = GameObject.Find("/PlanetMenu/Panel");

		// Setup the displays
		shipDisplay = GameObject.Find("/PlanetMenu/Panel/DisplayHolder/ShipDisplay");
		troopDisplay = GameObject.Find("/PlanetMenu/Panel/DisplayHolder/TroopDisplay");
		peopleDisplay = GameObject.Find("/PlanetMenu/Panel/DisplayHolder/PeopleDisplay");
		productionDisplay = GameObject.Find("/PlanetMenu/Panel/DisplayHolder/ProductionDisplay");
		planetDisplay = GameObject.Find("/PlanetMenu/Panel/DisplayHolder/PlanetDisplay");

		
		connectedPlanets = new List<GameObject>();
		listOfRoutes = new List<GameObject>();
		random = new System.Random ();
		fleetOverPlanet = null;
	}

	// Use this for initialization
	void Start () {
		spice = random.Next (0, 100);
		defense = random.Next (0, 100);
		hasVisited = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")) {
			
		}
	}

	/**
	 * Detects mouse clicks, but only if a UI element does not interfere with the click
	 * @param eventData - Information about the event that we don't really care currently about
	 */
	public void OnPointerClick(PointerEventData eventData) {
		// Initialize the planet for the displays
		shipDisplay.GetComponent<Display>().setPlanet(gameObject);
		troopDisplay.GetComponent<Display>().setPlanet(gameObject);
		peopleDisplay.GetComponent<Display>().setPlanet(gameObject);
		productionDisplay.GetComponent<Display>().setPlanet(gameObject);
		planetDisplay.GetComponent<Display>().setPlanet(gameObject);

		// If the menu is closed, open it and show the currently selected tab
		tabManager.GetComponent<TabManager>().enableDisplayOnOpen();
		
		// Set the name for the planet display tab
		planetDisplay.GetComponent<PlanetDisplay>().setName(planetName);

		// Set the garrison amount for the troop display tab
		troopDisplay.GetComponent<TroopDisplay>().setGarrisons(garrisons);

		// Activate the main menu
		canvasUI.SetActive(true);
	}

	/**
	 * Adds a planet to the list of planets we are connected to via trade routes
	 * @param GameObject - The planet that we wish to add to our connected list
	 */
	public void addTradeRoute(GameObject planet) {
		this.connectedPlanets.Add(planet);
	}

	/**
	 * Returns a list of the planets we are connected to via trade routes
	 * @return List<GameObjects>
	 */
	public List<GameObject> getConnectedObjects() {
		return this.connectedPlanets;
	}

	/**
	 * Remove a trade route from the list of connected planets
	 * @param  GameObject The planet we wish to remove
	 */
	public void removeConnectedPlanet(GameObject planet) {
		connectedPlanets.Remove(planet);
		for (int i=listOfRoutes.Count-1; i >=0; i--) {
			Destroy((GameObject)listOfRoutes[i]);
			listOfRoutes.RemoveAt(i);
		}
	}

	/**
	 * Displays the planets that we are currently connected to via trade routes
	 * @return string - A list of planets we have trade relations with
	 */
	public string printConnectedPlanets() {
		string output = "";
		foreach (GameObject planet in connectedPlanets) {
			output += planet.GetComponent<Planet>().getName() + " - ";
		}
		return output;
	}

	/**
	 * Removes a trade route from this planet, based off a probability
	 * @param int - the probability that we will remove a trade route
	 */
	public void removeTradeRoute(int probability) {
		for (int i = connectedPlanets.Count - 1; i >= 0; i--) {
			int randomValue = random.Next(0,100);
			if (randomValue < probability) {
				connectedPlanets.RemoveAt(i);
			}
		}

		for (int i=listOfRoutes.Count-1; i >=0; i--) {
			Destroy((GameObject)listOfRoutes[i]);
			listOfRoutes.RemoveAt(i);
		}
	}

	/**
	 * Creates a number of lineRenderers to represent the trade routes between planets
	 * @param  GameObject - an empty gameobject holder to house the created trade route objects
	 */
	public void displayTradeRoutes(GameObject tradeRouterHolder) {
		for (int i=listOfRoutes.Count-1; i >=0; i--) {
			Destroy((GameObject)listOfRoutes[i]);
			listOfRoutes.RemoveAt(i);
		}

		foreach(GameObject planet in connectedPlanets) {
			GameObject lineRenderer = (GameObject)Instantiate(tradeRoute);
			lineRenderer.transform.parent = tradeRouterHolder.transform;
			this.listOfRoutes.Add(lineRenderer);
			Vector3 currPosition = gameObject.transform.position;
			Vector3 targetPosition = planet.transform.position;
			LineRenderer line = lineRenderer.GetComponent<LineRenderer>();
			line.SetPosition(0, currPosition);
			line.SetPosition(1, targetPosition);
			line.SetWidth(lineWidth,lineWidth);
		}
	}

	/**
	 * Sets the color of the trade route between planets
	 * @param Color - the color we want the trade route to be represented by
	 */
	public void setLineColor(Color c) {
		foreach(GameObject lineRenderer in listOfRoutes) {
			LineRenderer line = lineRenderer.GetComponent<LineRenderer>();
			line.SetColors(c,c);
		}
		
	}

	/**
	 * Sets the name of the planet
	 * Creates a game object (using a deprecated function) to display the name underneath the planet as well
	 * This will only create a name once
	 * @param The new name of the planet
	 * 
	 */
	public void setName(string name) {
		this.planetName = name;
		if (!createdNameObject) {
			createdNameObject = true;
			GameObject nameDisplay = (GameObject) Instantiate(planetNameDisplay);
			nameDisplay.transform.parent = this.transform;
			nameDisplay.transform.position = this.transform.position;
			nameDisplay.transform.position -= new Vector3(2.3f,5,0);
			nameDisplay.GetComponent<TextMesh>().text = name;
			nameDisplay.GetComponent<TextMesh>().fontSize = 20;
		}
	}

	/**
	 * Update both the number of units and set the color
	 * @param  Color - the color we want to set the planet to
	 * @param  numberOfUnits - the number of units we want to place on the planet
	 */
	public void changeColorAndSetUnits(Color color, int numberOfUnits) {
		setUnits(numberOfUnits);
		setToColor(color);
	}

	/**
	 * Sets the amount of units currently on the planet (only a simple number, currently)
	 * @param int - The number of units we want to place on the planet
	 */
	public void setUnits(int numberOfUnits) {
		garrisons = numberOfUnits;
	}

	/**
	 * Sets the planets color
	 * @param Color - the color we want to set the planet to
	 */
	public void setToColor(Color c) {
		renderer.material.SetColor("_Color", c);
	}

	/**
	 * Shifts the planet into the position provided by the x and y parameters
	 * @param The distance along the x coordinate system we want the planet to move along
	 * @param The distance along the y  coordinate system we want the planet to move along
	 */
	public void setPosition(int x, int y) {
		gameObject.transform.Translate(x,y,0);
	}

	/**
	 * Return the name of this planet
	 * @return string - the name of the planet
	 */
	public string getName() {
		return this.planetName;
	}

	/**
	 * Whether this planet has been removed during the creation of the galaxy (not currently implemented)
	 * @return {Boolean} - Whether the planet has been removed
	 */
	public bool hasBeenRemoved() {
		return this.isRemoved;
	}

	/**
	 * Sets if this planet has been removed by the creation of the galaxy
	 */
	public void setRemoval() {
		this.isRemoved = true;
	}

	/**
	 * Sets whether this planet has been visited during a search
	 * @return {Boolean} - Whether the planet has been visited during a search
	 */
	public bool hasBeenVisited() {
		return this.hasVisited;
	}

	/**
	 * Sets the status of whether this planet has already been visisted during a search
	 * @param {Boolean} - Whether or not the planet has been visisted
	 */
	public void setVisited(bool visitedStatus) {
		this.hasVisited = visitedStatus;
	}

	/**
	 * Gets the current placeholder for the position within the two-dimensional array in the parent gameObject
	 * @return int - The first coordinate for where this planet is located in the parents container
	 */
	public int getIndexForX() {
		return this.galaxyPositionX;
	}

	/**
	 * Gets the current placeholder for the position within the two-dimensional array in the parent gameObject
	 * @return int - The second coordinate for where this planet is located within the parents container
	 */
	public int getIndexForY() {
		return this.galaxyPositionY;
	}

	/**
	 * Sets the location of where this object is located within the parents two-dimensional array (in this case, the galaxy)
	 * @param int - the first coordinate (representing the depth of the array)
	 * @param int - the second coordinate (representing the )
	 */
	public void setIndex(int positionX, int positionY) {
		this.galaxyPositionX = positionX;
		this.galaxyPositionY = positionY;
	}

	public void setFleet(GameObject fleet) {
		fleetOverPlanet = fleet;
	}

	public GameObject getFleetOverPlanet() {
		return fleetOverPlanet;
	}
}
