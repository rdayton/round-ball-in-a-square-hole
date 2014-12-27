using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class MainCameraScript : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
	
		offset = transform.position;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		BannerView adBanner = new BannerView ("ca-app-pub-4900110391044614/8668921088",AdSize.Banner ,AdPosition.Top);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		adBanner.LoadAd(request); 

	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	
	}
}
