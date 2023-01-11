using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControler3B_G : MonoBehaviour {

	public GameObject Emily;
	public GameObject KevinGo;
	public GameObject DanV;
	public GameObject PamV;
	public GameObject CharlieV;
	public GameObject Nadar;

	private Waypoint_1WPS Emily3B;
	private Waypoint_1WPS KevinGo3B;
	private Waypoint_1WPS DanV3B;
	private Waypoint_1WPS PamV3B;
	private Waypoint_1WPS CharlieV3B;

	public bool NextLVL3BG;
	public int LevelN3BG;


	// Use this for initialization
	void Start () {
		Emily3B = Emily.GetComponent<Waypoint_1WPS> (); 
		DanV3B = DanV.GetComponent<Waypoint_1WPS> (); 
		PamV3B = PamV.GetComponent<Waypoint_1WPS> (); 
		CharlieV3B = CharlieV.GetComponent<Waypoint_1WPS> (); 
	}
	
	// Update is called once per frame
	void Update () {
		if (NextLVL3BG)
		{
			SceneManager.LoadScene(LevelN3BG);
		}
	
	}


	public void EmilyWP3B(){
		Emily3B.firstWPs = true;
	}
	public void DanWV3B(){
		DanV3B.firstWPs = true;	
	}
	public void PamWV3B(){
		PamV3B.firstWPs = true;
	}
	public void CharlieWV3B(){
		CharlieV3B.firstWPs = true;
		Nadar.SetActive (true);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			NextLVL3BG = true;
		}
	}
}
