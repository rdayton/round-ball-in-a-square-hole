using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class MainCameraScript : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	
	}
}
