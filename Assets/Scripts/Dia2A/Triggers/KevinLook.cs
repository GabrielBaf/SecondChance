using UnityEngine;
using System.Collections;

public class KevinLook : MonoBehaviour {

    public bool KevinHere;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Kevin")
        {
            KevinHere = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Kevin")
        {
            KevinHere = false;
        }
    }

}
