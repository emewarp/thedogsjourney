using UnityEngine;
using System.Collections;

public class Javi_DanoHacha : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag.Equals ("Player")) {
			//quita vida (si puede): attack
			//Debug.Log ("prueba"); //esto ok 
			//this.GetComponent<Animation>().Play("attack");
			collision.collider.gameObject.SendMessage("Injure",20);
			//FALTAAAAAA !!!
			//mandar mensaje al player de que le quitas DAMAGE puntos de vida
			//collision.gameObject.SendMessage ("Injure", DAMAGE);
			//this.active = true;
		}
	}

		//dano al jugador
}

