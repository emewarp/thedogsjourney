
using UnityEngine;
using System.Collections;

public class Carlos_PlayerController : MonoBehaviour {

	private bool linterna;

	// Use this for initialization
	void Start () {
		linterna = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void FinishLevel(){
		if (linterna == true)
			//cambiar de escena
			Debug.Log("Enhorabuena! Has superado el nivel!");
	}

	public void LinternaCogida (){
		linterna = true;
		//Debug.Log ("Tienes la linterna");
	}
}
