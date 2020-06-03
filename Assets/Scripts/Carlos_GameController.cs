using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Carlos_GameController : MonoBehaviour {

	private static GameObject[] Life;
	private static int vidas = 3;
	private bool dead;

	Texture2D blk;
	public bool fade;
	public float alph = 0;


	public static bool mazUnoFin = false;
	public static bool mazDosFin = false;

	// Use this for initialization
	void Start () {
		Life = GameObject.FindGameObjectsWithTag ("Heart");
		dead = false;
		fade = false;

		mantenerVidas ();

		//make a tiny black texture para la MUERTE
		blk = new Texture2D (1, 1);
		blk.SetPixel (0, 0, new Color(0,0,0,0));
		blk.Apply ();
	}
	
	// Update is called once per frame
	void Update () {

		if (vidas == 0 && !dead) {
			Die ();
		}

		//apagar pantalla
		if (fade) {
			if (alph < 1) {
				alph += Time.deltaTime * .2f;
				if (alph > 1) {alph = 1f;}
				blk.SetPixel (0, 0, new Color (0, 0, 0, alph));
				blk.Apply ();
			}
		}
			
	
	}

	public void CargarBosque(){
		SceneManager.LoadScene ("Bosque");
	}

	public IEnumerator FinishLevel1(bool level1sup){
		if (level1sup == true) {
			//cambiar de escena
			//Debug.Log("Enhorabuena! Has superado el nivel!");
			yield return new WaitForSeconds (4.5f);
			SceneManager.LoadScene ("Cueva");		
		}

	}

	public void FinishLevel2(){
		SceneManager.LoadScene ("Mains");		
	}

	public void CargarMazmorraVerde(){
		Carlos_GameController.mazDosFin = true;
		SceneManager.LoadScene ("MazmorraVerde");
	}

	public void CargarMazmorraRosa(){
		Carlos_GameController.mazUnoFin = true;
		SceneManager.LoadScene ("MazmorraRosa");
	}

	public static void Damage (){
		if (vidas > 0) {
			Destroy (Life [vidas - 1]);
			vidas--;		
		}
	}


	//MUERTE
	public void Die(){
		fade = true;
		dead = true;
		Invoke ("CargarMismaEscena", 4f);
	}

	void CargarMismaEscena(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		fade = false;
		dead = false;
		vidas = 3;
	}

	void OnGUI(){
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height),blk);
	}

	private void mantenerVidas(){
		for (int i = 0; i < 3; i++)
			Life [i].SetActive(false);

		for (int i = 0; i < vidas; i++)
			Life [i].SetActive(true);	
	}

}
