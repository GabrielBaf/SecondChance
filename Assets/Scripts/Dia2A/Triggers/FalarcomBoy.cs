using UnityEngine;
using System.Collections;

public class FalarcomBoy : MonoBehaviour {

    public bool PlayerHere;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Charlie")
        {
            PlayerHere = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Charlie")
        {
            PlayerHere = false;
        }
    }

}
