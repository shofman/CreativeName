using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/**
 * Class that changes the mouse texture between multiple states:
 * 	Targeted - Our targeted mouse texture (crosshairs) - used to indicate an action can be performed
 * 	Default - Our normal mouse texture, used to indicate we are at a normal state
 */
public class TargetMouseTexture : MonoBehaviour {
	// The imported texture (not used due to its size) - set dynamically
	public Texture2D accessibleBlankTexture;

	// Dimension that we want our mouse texture to be
	private static int textureDimension = 32;

	// The texture we are using for the target symbol
	private static Texture2D targetTexture;

	// The texture we are using for the default mouse (copied from imported blanktexture)
	private static Texture2D blankTexture;
	
	/**
	 * Setup the textures for reuse
	 */
	void Awake() {
		targetTexture = createTargetMouse();
		blankTexture = createEmptyMouseTexture();
	}

	/**
	 * Alternates between the targeted mouse state and the normal mouse state
	 */
	public void toggleTargetedMouse() {
		if (MouseState.instance().getCurrentMouseState() == MouseState.State.MoveShip) {
			setMouseToNormal();
		} else {
			changeMouseToTarget();
		}
	}

	/**
	 * Changes the mouse to be the crosshairs (to indicate we are targeting something)
	 */
	public static void changeMouseToTarget() {
		Vector2 cursorPosition = new Vector2(textureDimension/2, textureDimension/2);
		Cursor.SetCursor(targetTexture, cursorPosition, CursorMode.ForceSoftware);
		MouseState.instance().setCurrentMouseState(MouseState.State.MoveShip);
	}

	/**
	 * Changes the mouse to be our default mouse (to indicate we can click normally)
	 */
	public static void setMouseToNormal() {
		Vector2 cursorPosition = new Vector2(textureDimension/4, textureDimension/2);
		Cursor.SetCursor(blankTexture, cursorPosition, CursorMode.ForceSoftware);
		MouseState.instance().setCurrentMouseState(MouseState.State.Default);
	}

	/**
	 * Returns the target mouse texture (if needed by other classes)
	 * @return Texture2D - The crosshairs texture to indicate a targeted action
	 */
	public Texture2D getTargetMouseTexture() {
		if (targetTexture == null) {
			targetTexture = createTargetMouse();
		}
		return targetTexture;
	}

	/**
	 * Creates the target texture
	 * @return Texture2D - A new targeted Texture
	 */
	private Texture2D createTargetMouse() {
		targetTexture = new Texture2D(textureDimension, textureDimension);

		// Initializes the texture to blank
		for(int i=0; i<textureDimension; i++) {
			for(int j=0; j<textureDimension; j++) {
				targetTexture.SetPixel(i,j, new Color(0,0,0,0));
			}
		}

		// Creates a black crosshair pattern down the middle of the texture
		for(int i=0; i<textureDimension; i++) {
			targetTexture.SetPixel(i, textureDimension/2, Color.black);
			targetTexture.SetPixel(textureDimension/2, i, Color.black);
		}

		// Apply the pixel changes to the texture and return it
		targetTexture.Apply();
		return targetTexture;
	}

	/**
	 * Creates the normal mouse texture
	 * @return Texture2D - A new default mouse Texture
	 */
	private Texture2D createEmptyMouseTexture() {
		blankTexture = new Texture2D(textureDimension, textureDimension);

		// Initialize the texture to blank
		for(int i=0; i<textureDimension; i++) {
			for(int j=0; j<textureDimension; j++) {
				blankTexture.SetPixel(i,j, new Color(0,0,0,0));
			}
		}

		// Our blank texture is larger than our desired size, so we scale it down
		for(int i=0; i<128; i++) {
			for(int j=0; j<128; j++) {
				// Only add pixels to our texture if they are non-transparent
				Color c = accessibleBlankTexture.GetPixel(i,j);
				if (c.a != 0) {
					blankTexture.SetPixel((int)i/4,(int)j/4, c);	
				}
				
			}
		}

		// Apply the pixel changes to the texture and return it
		blankTexture.Apply();
		return blankTexture;
	}
}