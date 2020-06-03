using UnityEngine;
using System.Collections;

public class Carlos_DeadTrees : MonoBehaviour {

	private bool fallen;
	private bool rotar;
	private float timeRotation;
	private float initTime;

	private AudioSource DeadTreeAS;
	private bool activarSonido;

	// Use this for initialization
	void Start () {
		rotar = false;
		fallen = false;
		timeRotation = 0;
		activarSonido = true;

		DeadTreeAS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if (rotar && !fallen) {
			timeRotation = Time.time;
			transform.Rotate (new Vector3 (60,0,-90) * Time.deltaTime * 0.5f);
			if (activarSonido)
				audioFallen ();
			if (timeRotation - initTime >= (1.2f)) {
				rotar = false;
				fallen = true;
			}	
		}	
	}

	public void Caer(){
		rotar = true;
		initTime = Time.time;
	}

	void audioFallen(){
		DeadTreeAS.Play();
		activarSonido = false;
	}
}
