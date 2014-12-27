using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ballScript : MonoBehaviour {

	public float speed;
	private int count;
	public Text countText;
	private Vector3 currAc;
	private Vector3 zeroAc;

	private float sensH = 10;
	private float sensV = 10;
	private float smooth = 0.5f;
	private float GetAxisH = 0;
	private float GetAxisV = 0;
	public float speedAc = 25;
	private int failCount = 0;
	
	// Use this for initialization
	void Start () {
	
		count = 0;
		setCountText ();
		resetAxes ();

	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y < -10)
		{
			Application.LoadLevel(Application.loadedLevel);
			failCount++;
		}

	
	}

	void FixedUpdate() {

		if (SystemInfo.deviceType == DeviceType.Desktop) 
		{
						float moveHorizontal = Input.GetAxis ("Horizontal");
						float moveVertical = Input.GetAxis ("Vertical");

						Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
		} 
		else 
		{
			//get input by accelerometer
			currAc = Vector3.Lerp(currAc, Input.acceleration-zeroAc, Time.deltaTime/smooth);
			GetAxisV = Mathf.Clamp(currAc.y * sensV, -1, 1);
			GetAxisH = Mathf.Clamp(currAc.x * sensH, -1, 1);
			// now use GetAxisV and GetAxisH instead of Input.GetAxis vertical and horizontal
			// If the horizontal and vertical directions are swapped, swap curAc.y and curAc.x
			// in the above equations. If some axis is going in the wrong direction, invert the
			// signal (use -curAc.x or -curAc.y)
			
			Vector3 movement = new Vector3 (GetAxisH, 0.0f, GetAxisV);
			
			rigidbody.AddForce(movement * speedAc );
			
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Pickup") {
			
						other.gameObject.SetActive (false);
						count++;
						setCountText ();
		} 
		else if (other.gameObject.tag == "NextLevel")
		{

			Application.LoadLevel(Application.loadedLevel+1);


		}

	}

	void setCountText(){
		countText.text = "Count: " + count;

		}

	void resetAxes()
	{
		zeroAc = Input.acceleration;
		currAc = Vector3.zero;
		
	}
	
	
}
