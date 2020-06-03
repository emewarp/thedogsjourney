using UnityEngine;
using System.Collections;

public class Jorge_PuertaPerro : MonoBehaviour
{

	private bool abrir;
	private Vector3 posTarget;

	void Start ()
	{
		abrir = false;
		posTarget = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
		
	}
	
	
	void Update () {

		if (abrir)
		{
			transform.position = Vector3.MoveTowards(transform.position, posTarget, Time.deltaTime * 0.5f);
		}
	}

	void AbrirPuerta()
	{
		abrir = true;
		
	}
}
