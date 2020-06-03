using UnityEngine;
using System.Collections;

public class Jorge_Estalactita : MonoBehaviour {

	private Rigidbody rb;

	public GameObject humoPrefab, parteEstalac1, parteEstalac2, parteEstalac3;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	

	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag.Equals ("Floor")) {
			foreach (ContactPoint contact in col.contacts) {
				
				GameObject humo = Instantiate (humoPrefab, contact.point, Quaternion.identity) as GameObject;
				Destroy (humo, 10);
				GameObject parte1 =  Instantiate (parteEstalac1, contact.point + new Vector3(-0.5f, 0, -1), Quaternion.Euler(0, 45, 0)) as GameObject;
				GameObject parte2 =  Instantiate (parteEstalac2, contact.point + new Vector3(0.2f, 0, 0), Quaternion.Euler(0, 45, -40)) as GameObject;
				GameObject parte3 =  Instantiate (parteEstalac3, contact.point + new Vector3(0.4f, 0, 0.4f), Quaternion.Euler(0, 35, 20)) as GameObject;
				Destroy (parte1, 30);
				Destroy (parte2, 30);
				Destroy (parte3, 30);
			}

			Destroy (this.gameObject);



		} else {
			rb.constraints = RigidbodyConstraints.None;
			rb.constraints = RigidbodyConstraints.FreezeRotationX 
				| RigidbodyConstraints.FreezeRotationY
				| RigidbodyConstraints.FreezeRotationZ
				| RigidbodyConstraints.FreezePositionX
				| RigidbodyConstraints.FreezePositionZ;

		}
			
	}

	void Destroy(){
		Destroy (this);
	}




}
