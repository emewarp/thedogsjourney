using UnityEngine;
using System.Collections;

public class Jorge_Placa_de_Presion : MonoBehaviour {

	private GameObject puerta;

	// Use this for initialization
	void Start () {
		puerta = GameObject.FindGameObjectWithTag ("Puerta");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag.Equals ("Objeto")) {
			puerta.SendMessage ("AbrirPuerta");
		}
		/*else if (col.gameObject.tag.Equals ("Player")) {
			print ("exito");
			puerta.SendMessage ("AbrirPuerta");
		}*/
	}
}
