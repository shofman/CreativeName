using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Planet : MonoBehaviour, IPointerClickHandler {
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
	List<GameObject> connectedPlants;
	List<GameObject> listOfRoutes;

	public GameObject planetNameDisplay;
	public GameObject tradeRoute;
	public float lineWidth;
	
	GameObject canvasUI;
	GameObject planetInfo;
	GameObject planetGarrison;
	System.Random random;

	void Awake() {
		planetInfo = GameObject.Find("/PlanetMenu/Panel/PlanetInfo");
		planetGarrison = GameObject.Find("/PlanetMenu/Panel/PlanetGarrison");
		canvasUI = GameObject.Find("/PlanetMenu");
		connectedPlants = new List<GameObject>();
		listOfRoutes = new List<GameObject>();
		random = new System.Random ();
	}

	// Use this for initialization
	void Start () {
		spice = random.Next (0, 100);
		defense = random.Next (0, 100);
		hasVisited = false;
		canvasUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")) {
		}
	}

	public void OnPointerClick(PointerEventData eventData) {
		planetInfo.GetComponent<PlanetDisplay>().setName(planetName);
		planetGarrison.GetComponent<PlanetDisplay>().setGarrisons(garrisons);
		canvasUI.SetActive(true);
	}

	public void addTradeRoute(GameObject planet) {
		this.connectedPlants.Add(planet);
	}

	public List<GameObject> getConnectedPlanets() {
		return this.connectedPlants;
	}

	public void removeConnectedPlanet(GameObject planet) {
		connectedPlants.Remove(planet);
		for (int i=listOfRoutes.Count-1; i >=0; i--) {
			Destroy((GameObject)listOfRoutes[i]);
			listOfRoutes.RemoveAt(i);
		}
	}

	public string printConnectedPlanets() {
		string output = "";
		foreach (GameObject planet in connectedPlants) {
			output += planet.GetComponent<Planet>().getName() + " - ";
		}
		return output;
	}

	public void removeTradeRoute(int probability) {
		for (int i = connectedPlants.Count - 1; i >= 0; i--) {
			int randomValue = random.Next(0,100);
			if (randomValue < probability) {
				connectedPlants.RemoveAt(i);
			}
		}

		for (int i=listOfRoutes.Count-1; i >=0; i--) {
			Destroy((GameObject)listOfRoutes[i]);
			listOfRoutes.RemoveAt(i);
		}
	}

	public void displayTradeRoutes(GameObject tradeRouterHolder) {
		for (int i=listOfRoutes.Count-1; i >=0; i--) {
			Destroy((GameObject)listOfRoutes[i]);
			listOfRoutes.RemoveAt(i);
		}

		foreach(GameObject planet in connectedPlants) {
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

	public void setLineColor(Color c) {
		foreach(GameObject lineRenderer in listOfRoutes) {
			LineRenderer line = lineRenderer.GetComponent<LineRenderer>();
			line.SetColors(c,c);
		}
		
	}

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

	public void changeColorAndSetUnits(Color color, int numberOfUnits) {
		setUnits(numberOfUnits);
		setToColor(color);
	}

	public void setUnits(int numberOfUnits) {
		garrisons = numberOfUnits;
	}

	public void setToColor(Color c) {
		renderer.material.SetColor("_Color", c);
	}

	public void setPosition(int x, int y) {
		gameObject.transform.Translate(x,y,0);
	}

	public string getName() {
		return this.planetName;
	}

	public bool hasBeenRemoved() {
		return this.isRemoved;
	}

	public void setRemoval() {
		this.isRemoved = true;
	}

	public bool hasBeenVisited() {
		return this.hasVisited;
	}

	public void setVisited(bool visitedStatus) {
		this.hasVisited = visitedStatus;
	}

	public int getIndexForX() {
		return this.galaxyPositionX;
	}

	public int getIndexForY() {
		return this.galaxyPositionY;
	}

	public void setIndex(int positionX, int positionY) {
		this.galaxyPositionX = positionX;
		this.galaxyPositionY = positionY;
	}
}
