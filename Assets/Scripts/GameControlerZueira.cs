using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControlerZueira : MonoBehaviour {

	public GameObject Kevin;
	public GameObject BigB;
	public GameObject Dan;
	public GameObject Charlie;

	private Waypoint_1WPS Dan3BZ;
	private Waypoint_1WPS Kevin3BZ;
	private Waypoint_1WPS BigB3BZ;
	private Waypoint_1WPS Char3BZ;

	public bool NextLVLZu;
	public int Leve3BZ;




	// Use this for initialization
	void Start () {
		Dan3BZ = Dan.GetComponent<Waypoint_1WPS> (); 
		Kevin3BZ = Kevin.GetComponent<Waypoint_1WPS> (); 
		BigB3BZ = BigB.GetComponent<Waypoint_1WPS> (); 
		Char3BZ = Charlie.GetComponent<Waypoint_1WPS> (); 
	}
	
	// Update is called once per frame
	void Update () {
		if (NextLVLZu)
		{
			SceneManager.LoadScene(Leve3BZ);
		}
	
	}
	public void SaindoZ(){
		Dan3BZ.firstWPs = true;
		Kevin3BZ.firstWPs = true;
		BigB3BZ.firstWPs = true;
	}
	public void CharCor(){
		Char3BZ.firstWPs = true;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			NextLVLZu = true;
		}
	}
}
