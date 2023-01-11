using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SairP : MonoBehaviour {
	
	public bool SairPis;

	void Start (){
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			SairPis = true;
		}
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			SairPis = false;
		}
	}

	void Update (){
		if (SairPis == true) {
			SceneManager.LoadScene ("PartyG4");
		}

	}


}
