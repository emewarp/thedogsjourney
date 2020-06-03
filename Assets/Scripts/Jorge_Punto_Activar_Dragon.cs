using UnityEngine;
using System.Collections;

public class Jorge_Punto_Activar_Dragon : MonoBehaviour
{

	private GameObject dragon;
	public GameObject perro;

	private bool dragonDespierto;
	private AudioSource[] themes;
	void Start () {

	 	dragon = GameObject.FindGameObjectWithTag("Dragon");
		dragonDespierto = false;
		themes = GetComponents<AudioSource> ();

	}
	
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag.Equals("Player"))
		{
			if (dragon != null && !dragonDespierto) {
				themes [0].Stop ();
				perro.GetComponent<AudioSource> ().enabled = false;
				Invoke ("BattleTheme", 4);
				dragon.SendMessage("DespertarDragon");
				dragonDespierto = true;


			}
				
		}
	}

	void BattleTheme(){
		themes [1].Play ();
	}
}
