using UnityEngine;
using System.Collections;

public class Playending : MonoBehaviour {

    public GameObject GameController;
    private GC_School2 GameControllerScript;


	// Use this for initialization
	void Start () {

        GameControllerScript = GameController.GetComponent<GC_School2>();

	}
	
	// Update is called once per frame
	void Update () {
	


	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Charlie")
        {
            GameControllerScript.End = true;
            GameControllerScript.PlayerCut.SetActive(false);
        }
    }

}
