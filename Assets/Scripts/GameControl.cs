using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using GoogleMobileAds.Api;

using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public float speed = 2000;
	public static GameControl control;
	public int lives = 5; //TODO: change to load frome file later
	public GameObject player;
	//private Vector3 offset;
	
	public Text distanceDisplay;
	// Use this for initialization
	void Awake () 
	{
	
		if (control == null) 
		{
			DontDestroyOnLoad (gameObject);
			control = this;
		} 
		else if (control != this) 
		{
			Destroy (gameObject);
		}
		//offset = transform.position;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		
		BannerView adBanner = new BannerView ("ca-app-pub-4900110391044614/8668921088",AdSize.Banner ,AdPosition.Top);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		adBanner.LoadAd(request); 

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 100, 30), "Lives = " + lives);


	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/info.dat");

		PlayerData data = new PlayerData();
		data.lives = lives;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/info.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/info.dat", FileMode.Open);

			PlayerData data = (PlayerData) bf.Deserialize(file);
				
			file.Close();

			lives = data.lives;
		}

	}



}

[Serializable]
class PlayerData
{
	public int lives;
}
