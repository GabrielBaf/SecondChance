using UnityEngine;
using System.Collections;

public class IntroCutscene : MonoBehaviour {

    public GameObject CutChrlie;
    public GameObject CutCarro;
    public GameObject EntrarFesta;

    public GameObject Player;
    private PlayerMovement PMov;
    public GameObject Fade;

    public GameObject CamDea;
    public GameObject CamAct;

    private Waypoint_2WPS CutCharlieWP;
    private Animator Caranimator;
    private PlayerHere EntrarFestaPHere;

    public bool check;
    // Use this for initialization
    void Start () {

        CutCharlieWP = CutChrlie.GetComponent<Waypoint_2WPS>();
        Caranimator = CutCarro.GetComponent<Animator>();
        EntrarFestaPHere = EntrarFesta.GetComponent<PlayerHere>();
        PMov = Player.GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {

        if (EntrarFestaPHere.PHere && check)
        {
            CamDea.SetActive(false);
            CamAct.SetActive(true);
            Player.SetActive(true);
            //  Fade.SetActive(true);
            PMov.enabled = true;
            CutChrlie.SetActive(false);
            EntrarFesta.SetActive(false);
            check = false;
        }
	
	}

    public void WalkCharlie()
    {
        CutCharlieWP.secondWPS = true;
    }

    public void CarOut()
    {
        Caranimator.SetTrigger("Out"); CutCharlieWP.firstWPs = true;
    }

}
