using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CollisionScript : MonoBehaviour {
	//public AudioClip audioClip;


	void Start()
	{
		//audio.clip = audioClip;
	}
	
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("COLLIDED");

		float magnitude = collision.relativeVelocity.magnitude;
		Debug.Log("MAGNITUDE = "+ magnitude);


		if (magnitude > 20)
		{				
			audio.volume = .75f;
			//audio.Play();
			//AudioSource.PlayClipAtPoint(audioClip,transform.position);
		}
		else if(magnitude >10)
		{
			audio.volume = .5f;
		}
		else
		{
			audio.volume = .1f;
		}

		audio.Play();				


	}
}
