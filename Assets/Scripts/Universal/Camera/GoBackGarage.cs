using UnityEngine;
using System.Collections;

public class GoBackGarage : MonoBehaviour {

	public GameObject Player;
	public GameObject Fader;
	public Vector2 PlayerClassPosition;

	public bool PlayerHere;

	public GameObject CamCorG;
	public GameObject BoundCorG;
	public GameObject CamGarG;
	public GameObject BoundGarG;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (PlayerHere && Input.GetKey(KeyCode.Space))
		{
			Player.transform.position = PlayerClassPosition;
			CamCorG.SetActive(false);
			BoundCorG.SetActive(false);
			CamGarG.SetActive(true);
			BoundGarG.SetActive(true);
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