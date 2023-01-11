using UnityEngine;
using System.Collections;

public class FadetoSchool : MonoBehaviour {

    public bool CharlieHere;
    public GameObject Fade;

    public GameObject Player;
    private PlayerMovement Pmov;

    public GameObject CamDea;
    public GameObject BoundDea;
    public GameObject CamAct;
    public GameObject BoundAct;

    public GameObject Elizabeth;

    // Use this for initialization
    void Start () {

        Pmov = Player.GetComponent<PlayerMovement>();
        
            Pmov.enabled = false;
       
    }
	
	// Update is called once per frame
	void Update () {

        

        if (CharlieHere)
        {
            CharlieHere = false;
            StartCoroutine(FinishCutscene());
        }

	}

    IEnumerator FinishCutscene()
    {
        yield return new WaitForSeconds(2);
        Fade.SetActive(true);
        yield return new WaitForSeconds(2.5f); 
        CamDea.SetActive(false);
        BoundDea.SetActive(false);
        CamAct.SetActive(true);
        BoundAct.SetActive(true);
        Pmov.enabled = true;
        yield return new WaitForSeconds(2.5f);
        Elizabeth.SetActive(true);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player_Intro")
        {
            CharlieHere = true;
        }
    }

}
