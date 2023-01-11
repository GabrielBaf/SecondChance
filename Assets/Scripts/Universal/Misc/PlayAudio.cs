using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {

    public bool PlayerHere;
    public AudioSource source;
    public AudioClip soundFX;

    // Use this for initialization
    void Start () {
        source = source.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (PlayerHere && Input.GetKey(KeyCode.Space))
        {
            source.PlayOneShot(soundFX, 1);
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

}
