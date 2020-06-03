using UnityEngine;
using System.Collections;

public class PasarNivelEsfera : MonoBehaviour {

	Texture2D blk;
	public bool fade;
	public float alph;

	private GameObject gc;
	private bool entrar;

	void Start(){
		entrar = false;
		//make a tiny black texture
		blk = new Texture2D (1, 1);
		blk.SetPixel (0, 0, new Color(0,0,0,0));
		blk.Apply ();

		fade = false;
		gc = GameObject.FindGameObjectWithTag ("GameController");
	}
	// put it on your screen
	void OnGUI(){
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height),blk);
	}

	void Update () {

		/*if (!fade) {
			if (alph > 0) {
				alph -= Time.deltaTime * .2f;
				if (alph < 0) {alph = 0f;}
				blk.SetPixel (0, 0, new Color (0, 0, 0, alph));
				blk.Apply ();
			}
		} */

		if(Input.GetKeyDown(KeyCode.E) && entrar == true){
			StartCoroutine ("SendFinishLevel2");
		}

		if (fade) {
			if (alph < 1) {
				alph += Time.deltaTime;
				if (alph > 1) {alph = 1f;}
				blk.SetPixel (0, 0, new Color (0, 0, 0, alph));
				blk.Apply ();
			}
		}
	}

	//añadido
	void OnTriggerStay (Collider col){
		if (col.gameObject.tag.Equals ("Player")) {
			entrar = true;
			fade = true;
		}
	}

	IEnumerator SendFinishLevel2 (){
		yield return new WaitForSeconds (2f);
		gc.SendMessage ("FinishLevel2");
	}

}
