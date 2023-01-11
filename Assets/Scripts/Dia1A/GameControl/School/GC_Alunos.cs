using UnityEngine;
using System.Collections;

public class GC_Alunos : MonoBehaviour {

    public GameObject EmilyInside;
    public GameObject Andy;
    public GameObject LisaOut;
    public GameObject AnneOut;
    public GameObject Jackout;

    public GameObject Ronald;

    public GameObject MeninasAndamFora;
    private PlayerHere MeninasScript;
    //impede loop das meninas
    private bool ParardeAndar1 = false;

    //faz jack ir embora
    private bool jackembora = false;

    private Waypoint_1WPS RonaldWP;
    private Waypoint_1WPS EmilyInWPs;
    private Waypoint_1WPS AndyWPs;
    private NPCFacePlayer AndyFace;
    private Waypoint_1WPS LisaOutWP;
    private Waypoint_1WPS AnneOutWP;
    private Waypoint_2WPS JackOutWp;

	// Use this for initialization
	void Start () {

        RonaldWP = Ronald.GetComponent<Waypoint_1WPS>();
        EmilyInWPs = EmilyInside.GetComponent<Waypoint_1WPS>();
        AndyWPs = Andy.GetComponent<Waypoint_1WPS>();
        AndyFace = Andy.GetComponent<NPCFacePlayer>();
        LisaOutWP = LisaOut.GetComponent<Waypoint_1WPS>();
        AnneOutWP = AnneOut.GetComponent<Waypoint_1WPS>();
        JackOutWp = Jackout.GetComponent<Waypoint_2WPS>();
        MeninasScript = MeninasAndamFora.GetComponent<PlayerHere>();

    }
	
	// Update is called once per frame
	void Update () {

        if (MeninasScript.PHere && !ParardeAndar1)
        {
            LisaOutWP.firstWPs = true; AnneOutWP.firstWPs = true; ParardeAndar1 = true;
        }

        //loop no jack
        if(JackOutWp.currentPoint1 == JackOutWp.lastWP1 && !jackembora)
        {
            JackOutWp.currentPoint1 = 0; JackOutWp.firstWPs = true;
        }

	}

    public void EmilySaidaSala()
    {
        EmilyInWPs.firstWPs = true;
    }

    public void AndySai()
    {
        AndyWPs.firstWPs = true; AndyFace.enabled = false;
    }

    public void JackVai()
    {
        jackembora = true;
        JackOutWp.firstWPs = false;
        JackOutWp.secondWPS = true;
    }

    public void RonaldWalk()
    {
        RonaldWP.firstWPs = true;
    }

}
