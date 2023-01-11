using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KevinHere : MonoBehaviour {

	public bool KHere;

	void Start (){
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Kevin")
		{
			KHere = true;
		}
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Kevin")
		{
			KHere = false;
		}
	}

	void Update (){
		if (this.enabled) {
			SceneManager.LoadScene ("PartyG2");
		}
		if (KHere == true) {
			SceneManager.LoadScene ("PartyG2");
		}

		}


}