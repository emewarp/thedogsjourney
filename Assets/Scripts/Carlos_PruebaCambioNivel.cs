using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Carlos_PruebaCambioNivel : MonoBehaviour {

	public bool pasarNivel;

	// Use this for initialization
	void Start () {
		pasarNivel = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (pasarNivel)
			SceneManager.LoadScene ("Cueva");
			
	
	}
}
