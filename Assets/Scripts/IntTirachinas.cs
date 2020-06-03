using UnityEngine;
using System.Collections;

public class IntTirachinas : MonoBehaviour {

	public GameObject proyectil;
	public GameObject door1, door2;
	private bool pulsado;

	// Use this for initialization
	void Start () {
		pulsado = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.tag.Equals ("Bala") && pulsado == false) {
			Debug.Log ("Acierto!");
			//Cambiar color a verde
			transform.GetComponent<Renderer> ().material.color = Color.green;
			//Abrir puerta
			door1.transform.Rotate(0,70,0); 
			door2.transform.Rotate (0, -70, 0);

			pulsado = true;
		}
	}
}
