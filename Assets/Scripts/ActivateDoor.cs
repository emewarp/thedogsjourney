using UnityEngine;
using System.Collections;

public class ActivateDoor : MonoBehaviour {
	public GameObject go;
	bool activated;
	public AudioSource audio1;
	public AudioSource audio2;
	// Use this for initialization
	void Start () {
		activated = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Activate(){
		if (!activated){
			audio1.Play ();	
			audio2.Play ();
			Destroy (go);
			activated = true;
			this.gameObject.transform.position += new Vector3 (0, -0.25f, 0);
		}

	}
}
