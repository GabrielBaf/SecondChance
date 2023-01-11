using UnityEngine;
using System.Collections;

public class GoToCorredorDan : MonoBehaviour {

	public GameObject Player;
	public GameObject Fader;
	public Vector2 PlayerClassPosition;
	public bool text;

	public bool PlayerHere;

	public GameObject CamDea;
	public GameObject BoundDea;
	public GameObject CamAct;
	public GameObject BoundAct;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (PlayerHere && Input.GetKeyUp(KeyCode.Space)|| text)
		{
			Player.transform.position = PlayerClassPosition;
			CamDea.SetActive(false);
			BoundDea.SetActive(false);
			CamAct.SetActive(true);
			BoundAct.SetActive(true);
			Fader.SetActive(true);
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			PlayerHere = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			PlayerHere = false;
		}
	}

	public void Fade()
	{
		gameObject.SetActive(false);
	}

}