using UnityEngine;
using System.Collections;

public class Marta_WolfController : MonoBehaviour {


	private bool active;
	private Vector3 dis;
	private Transform player;
	public const int DAMAGE = 1; //dano X/loquesea
	public const int SEC_AFTER_ATTACK = 2; //espera 5 segundos antes de atacarte otra vez
	private float timeSinceLastAttack = 0.0F;
	private Animator wolf;

	private NavMeshAgent nav;
	private int wolfLife = 2;
	public GameObject ex;
	private TextMesh exclamacion;

	// Use this for initialization
	void Start () {
		active = false; //inicializado a false
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		wolf = GetComponent<Animator>();

		nav = GetComponent<NavMeshAgent>();
		exclamacion = ex.GetComponent<TextMesh> ();
	}

	// Update is called once per frame
	void Update () {
		if (active == true && wolfLife != 0) { //se pone en movimiento cuando ve al jugador (active=true)

			transform.LookAt (player); //para que mire siempre hacia el jugador

			nav.SetDestination(player.position);
		}

		if (wolfLife == 0)
			Die ();

	}


	//se pone en movimiento cuando ve al jugador
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			this.active = true;
			exclamacion.text = "!";
			exclamacion.color = Color.red;
			wolf.SetBool ("run", true);
		}
	}

	//si te toca te quita vida
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag.Equals ("Player") && (Time.time - this.timeSinceLastAttack) > SEC_AFTER_ATTACK) {
			//quita vida (si puede): attack
			collision.gameObject.SendMessage("Injure");
			this.timeSinceLastAttack = Time.time;			
			this.active = true;
		}

		if (collision.gameObject.tag.Equals ("Bala"))
			wolfLife--;

	}

	//muerte 
	void Die(){  
		active = false;
		nav.enabled = false;
		wolf.SetBool ("die", true);
		Destroy(this.gameObject, 0.3f); //desaparece del mapa

	}
}
