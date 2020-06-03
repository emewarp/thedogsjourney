using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {

	//public int force;

	// Use this for initialization
	void Start () {
		//Vector3 fwd = transform.TransformDirection(Vector3.forward);
		//if (Physics.Raycast(transform.position, fwd, 10))
		Destroy (this.gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if (!col.gameObject.tag.Equals ("Player"))
		//	col.gameObject.SendMessage ("beHurted");

		Destroy (this.gameObject);
	}
}
