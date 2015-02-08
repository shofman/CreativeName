using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BreadthFirstSearch : MonoBehaviour {

	public void breadthFirstSearchPlanets <T> (GameObject initialNode, GameObject[,] listOfPlanets, bool displayNames) where T : Component, IBreadthFirstSearchInterface {
		Queue searchQueue = new Queue();
		searchQueue.Enqueue(initialNode);

		for (int i=0; i<listOfPlanets.GetLength(0); i++) {
			for (int j=0; j<listOfPlanets.GetLength(1); j++) {
				listOfPlanets[i,j].GetComponent<T>().setVisited(false);
			}
		}

		while (searchQueue.Count != 0) {
			GameObject currPlanet = (GameObject) searchQueue.Dequeue();
			if (displayNames) {
				string name = currPlanet.GetComponent<T>().getName();
				Debug.Log(name);
			}
			//find the current index, use it to find the corresponding planet in the array, and set its visited status to true
			int xPos = currPlanet.GetComponent<T>().getIndexForX();
			int yPos = currPlanet.GetComponent<T>().getIndexForY();
			listOfPlanets[xPos,yPos].GetComponent<T>().setVisited(true);

			List<GameObject> connectedPlanets = new List<GameObject>(currPlanet.GetComponent<T>().getConnectedObjects());
			// displayPlanetList(connectedPlanets);
			for (int i=0; i<connectedPlanets.Count; i++) {
				int x = connectedPlanets[i].GetComponent<T>().getIndexForX();
				int y = connectedPlanets[i].GetComponent<T>().getIndexForY();
				if (!searchQueue.Contains(connectedPlanets[i]) && !listOfPlanets[x,y].GetComponent<T>().hasBeenVisited()) {
					searchQueue.Enqueue(connectedPlanets[i]);
				}
			}
		}
	}

}