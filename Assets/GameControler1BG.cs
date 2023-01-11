using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControler1BG : MonoBehaviour {
	public GameObject Books;
	public bool Books1B;

	public bool NextLVL1B;
	public int Leve1B;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Books1B) {
			Books.SetActive (true);
			Books1B = false;
		}
	}
	public void Pegar(){
		Books1B = true;
	}
	public void GoDia2B()
	{
        SceneManager.LoadScene("Dia2B_G");
	}
}
