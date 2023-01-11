using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Gamecontroler4AG : MonoBehaviour {

	public GameObject Kevin;

	public GameObject Bully;
	public GameObject IrP;

	private PlayerHere checkKevin;

	private Waypoints_4WPS Kevin4AG;

	public bool NextLVL4A;
	public int Leve4A;

	// Use this for initialization
	void Start () {
		Kevin4AG = Kevin.GetComponent<Waypoints_4WPS> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (NextLVL4A)
		{
			SceneManager.LoadScene("PartyG2");
		}

	
	}
	public void Beijo(){
		Kevin4AG.firstWPs = true;
	}
	public void CheckK (){
		Bully.SetActive(true);
	}
}
