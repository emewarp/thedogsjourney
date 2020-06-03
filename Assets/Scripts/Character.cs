using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {

	public GameObject lantern;
	public GameObject proyectil;
	public GameObject proyectilAux;
	public GameObject tirachinas;
	private float initFire = 0;
	private bool cogido;
	//private GameObject objCogido;
	public GameObject caja;
	public GameObject cajaPrefab;

	static private bool linterna = false;
	public GameObject endGame;

	// Use this for initialization
	void Start () {
		cogido = false;
	}
	
	// Update is called once per frame
	void Update () {

		//prueba daño
		if (Input.GetKeyDown(KeyCode.O))
			Injure ();

		//Apagar/Encender linterna
		if (linterna){
			if (Input.GetKeyDown (KeyCode.F)) {
				if (lantern.activeSelf) {
					lantern.SetActive(false);
				} else {
					lantern.SetActive(true);
				}
			}
		}
			
		//Disparar proyectiles
		if (Input.GetMouseButtonDown (0) && cogido == false) {
			proyectilAux.SetActive (true);
			tirachinas.SetActive (true);
			initFire = Time.time;
		}
		if(Input.GetMouseButtonUp(0) && cogido == false){
			float forceFire = Time.time - initFire;
			GameObject obj = Instantiate (proyectil, proyectilAux.transform.position, proyectilAux.transform.rotation) as GameObject;
			obj.transform.rotation = transform.rotation;
			Rigidbody rgb;
			rgb = obj.GetComponent<Rigidbody> ();
			Vector3 F = proyectilAux.transform.forward * forceFire * 100;
			rgb.AddForce (F);
			initFire = 0;
			proyectilAux.SetActive (false);
			tirachinas.SetActive (false);
		}
	}

	void FixedUpdate(){
	}

	//A partir de aquí es de Carlos_PlayerController

	public void LinternaCogida (){
		linterna = true;
		endGame.SendMessage ("nivelSuperable");
		//Debug.Log ("Tienes la linterna");
	}
	
	public void Injure (){
		Carlos_GameController.Damage ();
	}

}
