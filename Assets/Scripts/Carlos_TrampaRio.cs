using UnityEngine;
using System.Collections;

public class Carlos_TrampaRio : MonoBehaviour {

	private GameObject deadTree;
	private MeshCollider mcTrampa;

	// Use this for initialization
	void Start () {
		deadTree = GameObject.FindGameObjectWithTag ("DeadTree");
		mcTrampa = this.GetComponent<MeshCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag.Equals ("Player")) {
			//árbol cae
			deadTree.SendMessage("Caer");

			mcTrampa.enabled = false;
		}
	
	}

}
