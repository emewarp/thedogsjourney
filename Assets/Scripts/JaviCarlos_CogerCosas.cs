using UnityEngine;
using System.Collections;

public class JaviCarlos_CogerCosas : MonoBehaviour {

	private bool cogible;
	private bool cogido;
	public GameObject caja;
	public GameObject cajaPrefab;
	private GameObject cajaMapa;

	// Use this for initialization
	void Start () {
		cogible = false;
		cogido = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.E) && cogible) {
			if (!cogido) {
				caja.SetActive (true);
				Destroy (cajaMapa);
				//gameObject.GetComponent<BoxCollider> ().enabled = true;
				cogido = true;
			} else {
				caja.SetActive (false);
				//gameObject.GetComponent<BoxCollider> ().enabled = false;
				Instantiate (cajaPrefab, caja.transform.position, caja.transform.rotation);
				cogido = false;
			}
		}
	
	}

	void OnTriggerStay(Collider col){

		if (col.gameObject.tag.Equals ("Objeto")) {
			cogible = true;
			cajaMapa = col.gameObject;
		}
		
	}

	void OnTriggerExit(Collider col){

		if (col.gameObject.tag.Equals ("Objeto")) {
			cogible = false;
		}			

	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag.Equals ("Palanca")) {
			col.gameObject.SendMessage ("Activate");
		}	
	}
}
