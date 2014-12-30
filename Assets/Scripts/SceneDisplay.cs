using UnityEngine;
using System.Collections;

public class SceneDisplay : MonoBehaviour {

	private Texture2D[] imageArray; //= new Texture2D[Application.levelCount];
	private Rect[] buttonArray; //=  new Rect[Application.levelCount];

	private readonly int X = 25;
	private readonly int Y = 200;
	private readonly int HEIGHT = 75;
	private readonly int WIDTH = 75;
	private readonly int SPACE = 150;
	private int widthMultiplier;
	private int heightMultiplier = 0;
	private readonly int scenesThatAreNotLevels = 1;
	private int numberOfScenes;

	// Use this for initialization
	void Awake () {

		numberOfScenes = Application.levelCount - scenesThatAreNotLevels;

		imageArray = new Texture2D[numberOfScenes];
		buttonArray  =  new Rect[numberOfScenes];

		for (int i = 1; i < numberOfScenes; i++) 
		{
			widthMultiplier = (i%3);
			if(widthMultiplier == 0)
			{
				widthMultiplier = 3;
			}

			if(i%4 == 0)
			{
				heightMultiplier++;
				widthMultiplier = 1;
			}


			imageArray[i] = (Texture2D) Resources.Load("1scene", typeof(Texture2D)); // Assigns a texture named "center.png" to a Texture2D(center).
			buttonArray[i] = new Rect(X+(widthMultiplier*SPACE), Y+(heightMultiplier*SPACE) , HEIGHT, WIDTH);
			Debug.Log("i = "+ i + " "+ buttonArray[i].ToString());
		}

	
	}

	void OnGUI()
	{

		DisplayButtons();
	}

	private void DisplayButtons()
	{
		GUIContent content = new GUIContent();

		for (int i = 1; i < numberOfScenes; i++) 
		{
			/*
			if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
				Debug.Log("Clicked the button with an image");
			*/
			content.text = i.ToString();
			content.image = imageArray[i];

			GUI.skin.button.alignment = TextAnchor.MiddleCenter;

			if (GUI.Button(buttonArray[i], content))
			{
				Debug.Log("Clicked the " + i +" button with text");
				Application.LoadLevel(i);
			}
				

		}

	}
	

}
