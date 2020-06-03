using UnityEngine;
using System.Collections;

public class Jorge_Murcielago : MonoBehaviour {

	private bool moving, following, dead;
	private Animator anim;
	private GameObject player;
	private Vector3 playerOffset;
	private NavMeshAgent nav;
	private Rigidbody rb;
	public GameObject ex;
	private TextMesh exclamacion;
	private AudioSource sonido;


	void Start () {
		moving = false;
		following = false;
		dead = false;
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		nav = GetComponent<NavMeshAgent> ();
		nav.enabled = false;
		rb = GetComponent<Rigidbody> ();
		exclamacion = ex.GetComponent<TextMesh> ();
		sonido = GetComponent<AudioSource> ();



	}
	
	// Update is called once per frame
	void Update () {
		
		if (moving) {
			transform.LookAt (player.transform);
			transform.Rotate (new Vector3 (-90, -180, 180));
			transform.position += new Vector3 (0, -1, 0.5f) * Time.deltaTime;
			//rb.velocity = new Vector3 (0, -1, 0);
			if (transform.position.y <= 4.5f) {
				rb.constraints = RigidbodyConstraints.FreezePositionY;
				moving = false;
				following = true;

			}
				

		} else if (following) {
			nav.enabled = true;
			transform.LookAt (player.transform);
			transform.Rotate (new Vector3 (-90, -180, 180));
			if (nav.enabled) {				
				nav.SetDestination (player.transform.position);
			}

			

		}
			

	}


	void OnTriggerEnter(Collider col){
		if (!moving && col.tag.Equals("Player") && !following && !dead) {
			
			sonido.Play ();
			anim.SetBool ("isFlying", true);
			ex.transform.Rotate (new Vector3 (-90, -180, 180));
			exclamacion.color = Color.red;
			exclamacion.text = "¡";
			moving = true;

		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag.Equals ("Player")) {
			//DAMAGE PLAYER
		} else if (col.gameObject.name.Equals ("Bala(Clone)")) {
			Dead();
		}

	}

	void Dead(){
		dead = true;
		Destroy (ex);
		anim.SetBool ("isFlying", false);
		moving = false;
		following = false;
		//nav.enabled = false;
		rb.rotation = Quaternion.Euler (Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
		Destroy (gameObject, 10);
	}


}
