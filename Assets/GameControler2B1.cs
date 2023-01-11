using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControler2B1 : MonoBehaviour {

	public bool NextLVL2B1;
	public int Leve2B;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (NextLVL2B1)
		{
			SceneManager.LoadScene(12);
		}
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			NextLVL2B1 = true;
		}
	}
}
