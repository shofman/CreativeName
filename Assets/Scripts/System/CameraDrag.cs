using UnityEngine;
/**
 * Class allows the camera to move around the screen upon a click and drag
 * Also allows the user to zoom in with a right click (and drag)
 */
public class CameraDrag : MonoBehaviour {
	public float dragSpeedXY = 2;
	private Vector3 dragOrigin;

	void Update() {
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
			dragOrigin = Input.mousePosition;
			return;
		}

		if (Input.GetMouseButton(0)) {
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
			Vector3 move = new Vector3(pos.x * dragSpeedXY, pos.y * dragSpeedXY, 0);

			transform.Translate(move, Space.World);
			return;
		} else if (Input.GetMouseButton(1)) {
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
			Vector3 move = new Vector3(0, 0, pos.y*dragSpeedXY);
			transform.Translate(move, Space.World);
			return;
		}
	}
}