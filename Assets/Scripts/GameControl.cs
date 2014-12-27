using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;
	public int lives;
	// Use this for initialization
	void Awake () {
	
		if (control == null) {
						DontDestroyOnLoad (gameObject);
						control = this;
				} else if (control != this) {
						Destroy (gameObject);
				}
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
