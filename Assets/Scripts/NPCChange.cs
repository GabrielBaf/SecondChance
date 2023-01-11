using UnityEngine;
using System.Collections;

public class NPCChange : MonoBehaviour {

	public GameObject Dan2;
	public GameObject Pam2;
	public GameObject Char2;
	public bool encostou;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (encostou) {
			Pam2.SetActive (true);
			Dan2.SetActive (true);
			Char2.SetActive (true);
			encostou = false;
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Pamela") {
			encostou = true;
		}
	
	}
}
