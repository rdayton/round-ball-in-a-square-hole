using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void quit()
	{
		
		Application.Quit();
		
	}
	
	public void start()
	{
		Application.LoadLevel ("LevelSelect");
	}

	public void returnToMainMenu()
	{
		//TODO: limit use somehow so that it can't be abused to get around losing lives
		Application.LoadLevel(0);
	}
}
