using UnityEngine;
using System.Collections;

public class PlayerHere : MonoBehaviour {

    public bool PHere;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PHere = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PHere = false;
        }
    }


}

