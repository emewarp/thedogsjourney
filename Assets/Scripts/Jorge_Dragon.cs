using UnityEngine;
using System.Collections;
using UnityEngineInternal;


public class Jorge_Dragon : MonoBehaviour
{

	private enum Movimiento
	{
		enTecho,
		posicionandose,
		persiguiendo,
		atacando,
		muerto
	};

	private Movimiento movimiento;
	private Vector3 posFinal;
	private NavMeshAgent nav;
	private Animator anim;
	private GameObject player;
	private Rigidbody rb;
	
	private bool despertado, inmune;
	private int vida, fase;

	private GameObject[] archGates;

	public GameObject bolaFuegoPrefab, aim;
	private float nextFire, nextDamage;
	public GameObject ex;
	private TextMesh exclamacion;

	public AudioSource[] roars;
	public GameObject perro, ptoActivarDragon;
	private AudioSource battleTheme;

	void Start ()
	{
		despertado = false;
		inmune = true;
		movimiento = Movimiento.enTecho;
		posFinal = new Vector3(-46, 6.8f, 54);
		nav = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		player = GameObject.FindGameObjectWithTag("Player");
		
		vida = 30;
		fase = 1;

		archGates = GameObject.FindGameObjectsWithTag("Puerta");

		exclamacion = ex.GetComponent<TextMesh> ();

		roars = GetComponents<AudioSource> ();
		battleTheme = ptoActivarDragon.GetComponents<AudioSource> ()[1];

	
	}
	
	void Update () {
		//print(movimiento + " Vida: " + vida + " Fase:" + fase + " Inmune:" + inmune);

		if (movimiento == Movimiento.posicionandose)
		{
			inmune = true;
			if ((transform.position == posFinal && transform.rotation == Quaternion.identity) && (fase == 1 || fase == 3))
			{
				rb.useGravity = true;
				nav.enabled = true;
				anim.SetBool("walk", true);
				movimiento = Movimiento.persiguiendo;
			}
			else if ((transform.position == posFinal && transform.rotation == Quaternion.identity) && fase == 2)
			{
				anim.SetBool("walk", false);
				nextFire = Time.time;
				movimiento = Movimiento.atacando;
			}
			else
			{
				transform.position = Vector3.MoveTowards(transform.position, posFinal, Time.deltaTime);
				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, Time.deltaTime * 10);
			}

		}

		else if (movimiento == Movimiento.persiguiendo)
		{

			inmune = false;
			if (nav.enabled)
			{
				transform.LookAt(player.transform.position);
				nav.SetDestination(player.transform.position);
				if (fase == 3)
				{
					nav.speed = 4;
				}

			}
		}

		else if (movimiento == Movimiento.atacando)
		{
			inmune = false;
			if (Time.time > nextFire)
			{
				nextFire += 1;
				Instantiate(bolaFuegoPrefab, aim.transform.position, Quaternion.identity);
			}
		}

		else if (movimiento == Movimiento.muerto)
		{
			inmune = true;
		}

	}

	void DespertarDragon()
	{
		if (!despertado)
		{

			despertado = true;
			roars[0].Play ();
			movimiento = Movimiento.posicionandose;
			exclamacion.text = "!";
			exclamacion.color = Color.red;
		}
		
		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name.Equals ("Bala(Clone)") && !inmune) {
			vida--;
			if (vida == 20) {
				roars [1].Play ();
				fase = 2;
				nav.enabled = false;
				exclamacion.text = "!!";
				movimiento = Movimiento.posicionandose;
			} else if (vida == 10) {
				fase = 3;
				exclamacion.text = "!!!";
				nav.enabled = false;
				movimiento = Movimiento.posicionandose;
			} else if (vida <= 0) {
				roars [0].Play ();
				nav.enabled = false;
				rb.useGravity = false;
				Destroy (gameObject, 10);
				anim.SetTrigger ("dead");
			
				foreach (GameObject gate in archGates) {
					gate.SendMessage ("AbrirPuerta");

				}
				perro.GetComponent<AudioSource> ().enabled = true;
				battleTheme.Stop ();
				movimiento = Movimiento.muerto;
			}

		} else if (col.gameObject.tag.Equals ("Player")) {
			if (Time.time > nextDamage) {
				nextDamage = Time.time + 4;
				player.SendMessage ("Injure");
			}
		}
	}
}
