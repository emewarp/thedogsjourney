using UnityEngine;
using System.Collections;

public class Jorge_BolaFuego : MonoBehaviour
{

	private GameObject player;

	private Vector3 playerPosition;
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerPosition = player.transform.position;
		playerPosition.y += 0.5f;
		transform.LookAt(playerPosition);
		Destroy (gameObject, 3);

	}
	
	
	void Update ()
	{
		transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime*4);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			player.SendMessage ("Injure");
		}
		Destroy(gameObject);
		
	}
}
