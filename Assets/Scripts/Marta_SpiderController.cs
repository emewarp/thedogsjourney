using UnityEngine;
using System.Collections;

public class Marta_SpiderController : MonoBehaviour {

	//el player tiene que tener Rigid Body 

	private bool active;
	private Vector3 dis;
	private Transform player;
	private NavMeshAgent navMesh;
	public const int DAMAGE = 10; 
	public const int SEC_AFTER_ATTACK = 5; //espera 5 segundos antes de atacarte otra vez
	private float timeSinceLastAttack = 0.0F;
	private int health = 1; //vida
	public GameObject ex;
	private TextMesh exclamation;


	// Use this for initialization
	void Start () {
		active = false; //inicializado a false
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		navMesh = GetComponent<NavMeshAgent> ();
		exclamation = ex.GetComponent<TextMesh> ();
	
	}
	
	// Update is called once per frame
	void Update 	() {
		
		if (active == true) { //se pone en movimiento cuando ve al jugador (active=true)

			transform.LookAt (player.transform); //para que mire siempre hacia el jugador
			this.GetComponent<Animation>().Play("run");
			//dis = player.transform.position - this.transform.position;
			//this.transform.Translate (dis * Time.deltaTime); //para que vaya hacia el jugador

			navMesh.SetDestination (player.position);
		
			//transform.position = new Vector3(Mathf.Clamp(transform.position.x,-10,10),transform.position.y, Mathf.Clamp(transform.position.z,-40,0));

		}
	
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
	void OnCollisionEnter (Collision collision)
	{
		
		if (collision.gameObject.tag.Equals ("Player") && (Time.time - this.timeSinceLastAttack) > SEC_AFTER_ATTACK) {
			//quita vida (si puede): attack
				this.active = false;
				this.GetComponent<Animation>().Play("taunt");
				this.GetComponent<Animation>().Play("attack1");
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
		this.GetComponent<Animation>().Play("death1");
		GameObject.Destroy(this); //desaparece del mapa

	}



}
