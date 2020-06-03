using UnityEngine;
using System.Collections;

public class Jorge_Cofre : MonoBehaviour {

	public GameObject textoObj;
	private TextMesh texto;
	private bool activado;

	void Start () {
	
		texto = textoObj.GetComponent<TextMesh> ();
		activado = false;
	}
	

	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && activado) {
			//gameController.SendMessage("RecuperarVida");
		}
		
	}

	void OnTriggerEnter(Collider col){
		if (col.tag.Equals ("Player")) {
			texto.text = "Pulsa 'E' para\nrecuperar la salud";
			activado = true;

		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag.Equals ("Player")) {
			texto.text = "";
			activado = false;

		}
	}
}
