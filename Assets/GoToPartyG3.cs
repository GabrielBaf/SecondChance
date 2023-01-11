using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoToPartyG3 : MonoBehaviour {

	public bool CharlieFC;

	void Start (){
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			CharlieFC = true;
		}
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			CharlieFC = false;
		}
	}
	void Update (){
		if (CharlieFC == true) {
			SceneManager.LoadScene ("PartyG3");
		}
	}

	}
