using UnityEngine;
using System.Collections;

public class IntCaja : MonoBehaviour {

	private bool pulsado;
	public GameObject door;

	// Use this for initialization
	void Start () {
		pulsado = false; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.tag.Equals ("Objeto") && pulsado == false) {
			Debug.Log ("Acierto!");
			//Cambiar color a verde
		
			transform.GetComponent<Renderer> ().material.color = Color.green;

			//Abrir puerta
			door.transform.Rotate(0,90,0); 

			pulsado = true;
		}
	}
}
