using UnityEngine;
using System.Collections;

public class Marta_SkeletonController : MonoBehaviour {



	private bool active; //para controlar si ve al player
	private Vector3 dis; //distancia para que siga al player
	private Transform player; //para que actue sobre el player
	private NavMeshAgent navMesh;
	public const int DAMAGE = 1; //dano X/loquesea al player
	public const int SEC_AFTER_ATTACK = 5; //espera 5 segundos antes de atacarte otra vez
	private float timeSinceLastAttack = 0.0F; //
	private int health = 3; //vida
	public GameObject ex;
	private TextMesh exclamation;

	// Use this for initialization
	void Start () {
		active = false; //inicializado a false
		InvokeRepeating("dance",0,14);
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		navMesh = GetComponent<NavMeshAgent> ();
		exclamation = ex.GetComponent<TextMesh> ();
	}

	// Update is called once per frame
	void Update 	() {



		if (active == true) { //se pone en movimiento cuando ve al jugador (active=true)

		//	transform.LookAt (player); //para que mire siempre hacia el jugador
			//this.GetComponent<Animation>().Play("idle");
			CancelInvoke();
			this.GetComponent<Animation>().Play("run");
			//dis = player.transform.position - this.transform.position;
			//this.transform.Translate (dis * Time.deltaTime); //para que vaya hacia el jugador
			navMesh.SetDestination(player.position);

		}

	}

	void dance() {
		this.GetComponent<Animation>().Play("dance");
	}


	//se pone en movimiento cuando ve al jugador
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			this.active = true;
			exclamation.text = "!";
			exclamation.color = Color.red;
		}
	}

	//si te toca te quita vida
	//esto no funciona bien
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag.Equals ("Player") && (Time.time - this.timeSinceLastAttack) > SEC_AFTER_ATTACK) {
			
			//Debug.Log("prueba"); //esto ok 
			this.GetComponent<Animation>().Play("attack");

			//mandar mensaje al player de que le quitas DAMAGE puntos de vida
			//collision.gameObject.SendMessage ("Injure", DAMAGE); //comprobar que lo coge
			this.active = true;
		}
		if(collision.gameObject.tag.Equals("Bala")){
			InjureEnemy(1);
		}

	}

	//dano
	public void InjureEnemy (int damage)
	{
		//Debug.Log ("Entrakitarvida");
		if (this.health > damage) {
			this.health -= damage;
		} else {
			this.health = 0; //Dead
			Die();
		}
	}

	//muerte 
	void Die(){  
		this.health = 0;
		active = false;
		GameObject.Destroy (ex);
		this.GetComponent<Animation>().Play("idle");
		this.GetComponent<Animation>().Play("die");
		GameObject.Destroy(this); //desaparece del mapa

	}
}
