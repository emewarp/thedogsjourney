using UnityEngine;
using System.Collections;

public class Javier_FlotandoYDandoVueltas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (transform.up*30*Time.deltaTime);
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag.Equals ("Player")) {
			col.gameObject.SendMessage ("LinternaCogida");
			Destroy (this.gameObject);
		}
	}
}
