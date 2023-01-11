using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_Day2A_3_Diario : MonoBehaviour {

	public GameObject Player;
	public GameObject PlayerPijama;
	public GameObject PlayerEscreve;

	private PlayerMovement PPijamaMov;

	public GameObject Fader;

	public GameObject MesaSemLivro;
	public GameObject GuardaRoupa;
	public GameObject Cama;

	public int LevelN;

	// Use this for initialization
	void Start () {
		PPijamaMov = PlayerPijama.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void PegarDiario()
	{
		MesaSemLivro.SetActive(true);
	}

	public void TrocarRoupa()
	{
		Fader.SetActive(true);
		Player.SetActive(false);
		PlayerPijama.SetActive(true);

		PPijamaMov.enabled = false;
	}

	public void AndaPlayerìjama(){
		PPijamaMov.enabled = true;
	}

	public void Deitar(){
	
		PlayerPijama.SetActive(false);
		PlayerEscreve.SetActive(true);

	}

	public IEnumerator NextLevel(){
	
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene(LevelN);

	}


}
