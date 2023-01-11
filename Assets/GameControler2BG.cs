using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControler2BG : MonoBehaviour {

	public GameObject Kevin;
	public GameObject Dan;
	public GameObject BigB;
	public GameObject Charlinho;
	public GameObject Ajuda;
	public bool chegandosala;

	private Waypoint_1WPS Kevin2BZ;
	private Waypoints_4WPS Kevin2BZ2;
	private Waypoints_4WPS Charlie2BZ2;

	public bool NextLVL2B;
	public int Leve2B;

	// Use this for initialization
	void Start () {
		Kevin2BZ = Kevin.GetComponent<Waypoint_1WPS> ();
		Kevin2BZ2 = Kevin.GetComponent<Waypoints_4WPS> ();
		Charlie2BZ2 = Charlinho.GetComponent<Waypoints_4WPS> ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (NextLVL2B)
		{
			SceneManager.LoadScene(Leve2B);
		}
		if (chegandosala) {
			Kevin.SetActive (true);
			Dan.SetActive (true);
			BigB.SetActive (true);
			Charlinho.SetActive (true);
			Ajuda.SetActive (true);
			chegandosala = false;
		}
	
	}
	public void Treta(){
		chegandosala = true;
	}
	public void Furarfila(){
		Kevin2BZ.firstWPs = true;
	}
	public void Irprafila(){
		Kevin2BZ2.secondWPS = true;
	}
	public void Furoufila(){
		Charlie2BZ2.secondWPS = true;
		Kevin2BZ2.thirdWPs = true;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			NextLVL2B = true;
		}
	}

}
