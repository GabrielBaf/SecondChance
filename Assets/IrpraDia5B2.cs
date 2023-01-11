using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IrpraDia5B2 : MonoBehaviour {
	
		public bool CasHere;

		void Start (){
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player")
			{
			CasHere = true;
			}
		}


		void OnTriggerExit2D(Collider2D other)
		{
		if (other.tag == "Player")
			{
			CasHere = false;
			}
		}

		void Update (){
		if (CasHere == true) {
			SceneManager.LoadScene ("Dia5_B2");
			}

		}


	}