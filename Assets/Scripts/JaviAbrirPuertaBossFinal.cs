using UnityEngine;
using System.Collections;

public class JaviAbrirPuertaBossFinal : MonoBehaviour {
	private bool b = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Carlos_GameController.mazDosFin && Carlos_GameController.mazDosFin && b) {
			transform.Rotate (0, 77, 0);
			b = false;
		}
	}
}
