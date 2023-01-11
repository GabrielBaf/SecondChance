using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerNadando : MonoBehaviour {

	public GameObject Kevin;
	public GameObject Emily;
	public GameObject BigB;
	public GameObject Charlinho;
	public GameObject Steven;

	private Waypoints_4WPS Kevin3BN;
	private Waypoints_4WPS Emily3BN;
	private Waypoints_4WPS BigB3BN;
	private Waypoints_4WPS Charlinho3BN;
	private Waypoints_4WPS Steven3BN;
	private Waypoint_1WPS Steven3BN2;
	private Waypoint_1WPS Emily3BN2;
	private Waypoint_1WPS BigB3BN2;
	private Waypoint_1WPS Charlinho3BN2;
	private Waypoint_1WPS Kevin3BN2;

	public bool NextLVL3B;
	public int Leve3B;



	// Use this for initialization
	void Start () {
		Steven3BN2 = Steven.GetComponent<Waypoint_1WPS> ();
		Emily3BN2 = Emily.GetComponent<Waypoint_1WPS> ();
		BigB3BN2 = BigB.GetComponent<Waypoint_1WPS> ();
		Charlinho3BN2 = Charlinho.GetComponent<Waypoint_1WPS> ();
		Kevin3BN2 = Kevin.GetComponent<Waypoint_1WPS> ();
		Kevin3BN = Kevin.GetComponent<Waypoints_4WPS> (); 
		Emily3BN = Emily.GetComponent<Waypoints_4WPS> (); 
		BigB3BN = BigB.GetComponent<Waypoints_4WPS> (); 
		Charlinho3BN = Charlinho.GetComponent<Waypoints_4WPS> (); 
		Steven3BN = Steven.GetComponent<Waypoints_4WPS> (); 
	}
	
	// Update is called once per frame
	void Update () {
		if (NextLVL3B)
		{
			SceneManager.LoadScene(Leve3B);
		}

	
	}
	public void KevinW3BN(){
		Kevin3BN.firstWPs = true;
	}
	public void AllEntrar(){
		Kevin3BN.secondWPS = true;
		Emily3BN.firstWPs = true;
		BigB3BN.firstWPs = true;
		Charlinho3BN.firstWPs = true;
		Steven3BN.secondWPS = true;
	}
	public void NadandoV(){
	
		Steven3BN.thirdWPs = true;
		Emily3BN2.firstWPs = true;
		BigB3BN2.firstWPs = true;
		Charlinho3BN2.firstWPs = true;
		Kevin3BN2.firstWPs = true;
	}

	public void NadandoD(){

		Steven3BN2.firstWPs = true;
		Emily3BN2.firstWPs = true;
		BigB3BN2.firstWPs = true;
		Charlinho3BN2.firstWPs = true;
		Kevin3BN2.firstWPs = true;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			NextLVL3B = true;
		}
	}

}
