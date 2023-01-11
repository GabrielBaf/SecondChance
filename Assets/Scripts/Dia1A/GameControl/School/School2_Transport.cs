using UnityEngine;
using System.Collections;

public class School2_Transport : MonoBehaviour {

    public bool charlieHere;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "CharlieCut")
        {
            charlieHere = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "CharlieCut")
        {
            charlieHere = false;
        }
    }

}
