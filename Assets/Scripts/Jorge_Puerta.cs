using UnityEngine;
using System.Collections;

public class Jorge_Puerta : MonoBehaviour {

	private Transform pivot;
	private bool abierta;

	// Use this for initialization
	void Start () {
		abierta = false;
		pivot = transform.FindChild ("Pivot");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AbrirPuerta(){
		if (!abierta) {
			transform.RotateAround (pivot.transform.position, transform.up, 135);
			abierta = true;
		}

	}
}
