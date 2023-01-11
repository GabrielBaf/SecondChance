using UnityEngine;
using System.Collections;

public class Fader_Sound : MonoBehaviour {

   // private AudioSource source;
   // public AudioClip fadeSound;
    private Animator animator;

    public GameObject Player;
    private PlayerMovement Pmov;

  //  public int TimeOut;
  //  private bool soundcheck = false;

    // Use this for initialization
    void Start () {
   //     source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        Pmov = Player.GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {

        if (gameObject.activeSelf == true)
        {
      //      source.PlayOneShot(fadeSound, 1);
       //     soundcheck = true;
            Pmov.enabled = false;
            //StartCoroutine(TimetoGo());
        }

	}

    //private IEnumerator TimetoGo()
    //{
    //    yield return new WaitForSeconds(TimeOut);
    //    animator.Play("FadeOut_Events");
    //    Pmov.enabled = true; 
    //}

    public void Fade()
    {
        gameObject.SetActive(false);
    }

}
