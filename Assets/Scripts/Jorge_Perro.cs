using UnityEngine;
using System.Collections;

public class Jorge_Perro : MonoBehaviour {

	private GameObject player;

	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (player.transform.position);
	}
}
