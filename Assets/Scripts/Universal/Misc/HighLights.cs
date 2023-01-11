using UnityEngine;
using System.Collections;

public class HighLights : MonoBehaviour {

    public GameObject HighLight;
    public bool PlayerHere;
    public bool isInteracting;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (PlayerHere)
        {
            HighLight.SetActive(true);
        }
        //if (isInteracting)
        //{
        //    PlayerHere = false;
        //    HighLight.SetActive(false);
        //}
        else
        {
            HighLight.SetActive(false);
        }

        if(PlayerHere && Input.GetKey(KeyCode.Space))
        {
            PlayerHere = false;
           // isInteracting = true;
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
            isInteracting = false;
        }
    }

}
