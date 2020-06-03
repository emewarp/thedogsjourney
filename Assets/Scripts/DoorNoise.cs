using UnityEngine;
using System.Collections;

public class DoorNoise : MonoBehaviour {
	public AudioSource audio;
	private bool hasSounded;
	// Use this for initialization
	void Start () {
		hasSounded = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player" && hasSounded==false) {
			audio.Play();
			hasSounded=true;
		}
	}
}
