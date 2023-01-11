using UnityEngine;
using System.Collections;
[ExecuteInEditMode]

public class GoToDoor2 : MonoBehaviour {

    public GameObject Player;
    public GameObject Fader;
    public Vector2 PlayerClassPosition;

    public bool PlayerHere;

    public GameObject CamDea;
    public GameObject CamAct;

    //public AudioSource source;
    //public AudioClip doorSound;


    public bool test;
    // Use this for initialization
    void Start()
    {
     //   source = source.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerHere && Input.GetKeyUp(KeyCode.Space) || test)
        {
            Player.transform.position = PlayerClassPosition;
            CamDea.SetActive(false);
            CamAct.SetActive(true);
            Fader.SetActive(true);

           // source.PlayOneShot(doorSound, 1);
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
