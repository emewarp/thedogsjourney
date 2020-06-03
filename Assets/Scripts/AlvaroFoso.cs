using UnityEngine;
using System.Collections;

public class AlvaroFoso : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag.Equals ("Player")) {
			c.gameObject.SendMessage ("Injure");
			c.gameObject.SendMessage ("Injure");
			c.gameObject.SendMessage ("Injure");
		}
	}
}
