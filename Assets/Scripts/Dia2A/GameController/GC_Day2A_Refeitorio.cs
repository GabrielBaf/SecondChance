using UnityEngine;
using System.Collections;

public class GC_Day2A_Refeitorio : MonoBehaviour {

    public bool nada1 = false;

    public GameObject Player;
    public GameObject PlayerCut;
    private Vector2 ppos;
    public GameObject Jenny;
    public GameObject Jenna;
    public GameObject Chris;
    public GameObject James;
    public GameObject Emily;
    public GameObject Kevin;


    public GameObject RefCam;
    public GameObject CutCam;

    public Vector2 PlayerBackHome;

    public GameObject CamDea;
    public GameObject CamAct;
    public GameObject BoundDea;

    public GameObject EntertheLine_Col;

    private Waypoints_4WPS PlayerCutWPs;
    private Waypoint_1WPS JennyWPs;
    private Waypoint_2WPS JennaWPs;
    private Waypoint_3WPS ChrisWPs;
    private Waypoints_4WPS JamesWPs;
    private Waypoints_4WPS EmilyWPs;
    private Waypoint_2WPS KevinWPs;


    private NPCFacePlayer EmilyFace;
    private NPCFacePlayer JennyFace;

    private PlayerHere EntertheLine_Script;

    private PlayerMovement Pmov;

    

	// Use this for initialization
	void Start () {

        PlayerCutWPs = PlayerCut.GetComponent<Waypoints_4WPS>();
        JennyWPs = Jenny.GetComponent<Waypoint_1WPS>();
        JennaWPs = Jenna.GetComponent<Waypoint_2WPS>();
        ChrisWPs = Chris.GetComponent<Waypoint_3WPS>();
        JamesWPs = James.GetComponent<Waypoints_4WPS>();
        EmilyWPs = Emily.GetComponent<Waypoints_4WPS>();
        KevinWPs = Kevin.GetComponent<Waypoint_2WPS>();


        EmilyFace = Emily.GetComponent<NPCFacePlayer>();
        JennyFace = Jenny.GetComponent<NPCFacePlayer>();
        EntertheLine_Script = EntertheLine_Col.GetComponent<PlayerHere>();
        Pmov = Player.GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {

        //ativar de novo as conversas do charlie
        if (nada1)
        {
           Pmov.enabled = true;
            nada1 = false;
        }

        //Colocar Charlie na Fila
        if (EntertheLine_Script.PHere && Input.GetKey(KeyCode.Space))
        {
            PlayerCut.SetActive(true);
            PlayerCutWPs.firstWPs = true;

            RefCam.SetActive(false);
            CutCam.SetActive(true);
            StartCoroutine(PlayerOnHold());
        }

        //evitar problemas caso passe os textos rapidos demais

        if(ChrisWPs.secondWPS && ChrisWPs.thirdWPs || ChrisWPs.firstWPs && ChrisWPs.thirdWPs)
        {
            ChrisWPs.firstWPs = false; ChrisWPs.secondWPS = false; ChrisWPs.thirdWPs = true;
        }
        if (EmilyWPs.thirdWPs && EmilyWPs.fouthWPs || EmilyWPs.thirdWPs && EmilyWPs.fouthWPs && EmilyWPs.firstWPs || EmilyWPs.secondWPS && EmilyWPs.fouthWPs)
        {
            EmilyWPs.firstWPs = false; EmilyWPs.secondWPS = false; EmilyWPs.thirdWPs = false; EmilyWPs.fouthWPs = true;
        }
        if (JamesWPs.thirdWPs && JamesWPs.fouthWPs || JamesWPs.secondWPS && JamesWPs.fouthWPs || JamesWPs.firstWPs && JamesWPs.thirdWPs)
        {
            JamesWPs.firstWPs = false; JamesWPs.thirdWPs = false; JamesWPs.secondWPS = false; JamesWPs.fouthWPs = true;
        }
        if (JennaWPs.firstWPs && JennaWPs.secondWPS)
        {
            JennaWPs.firstWPs = false; JennaWPs.secondWPS = true;
        }

        if(PlayerCutWPs.firstWPs && PlayerCutWPs.secondWPS)
        {
            PlayerCutWPs.firstWPs = false; PlayerCutWPs.secondWPS = true;
        }

        if(PlayerCutWPs.firstWPs && PlayerCutWPs.thirdWPs || PlayerCutWPs.secondWPS && PlayerCutWPs.thirdWPs)
        {
            PlayerCutWPs.firstWPs = false; PlayerCutWPs.secondWPS = false; PlayerCutWPs.thirdWPs = true;
        }

        if(KevinWPs.firstWPs && KevinWPs.secondWPS)
        {
            KevinWPs.firstWPs = false; KevinWPs.secondWPS = true;
        }

    }

    //fila anda

    public void Anda1()
    {
        JennyFace.enabled = false;
        EmilyFace.enabled = false;

        JennyWPs.firstWPs = true;
        JennaWPs.firstWPs = true;
        ChrisWPs.firstWPs = true;
        JamesWPs.firstWPs = true;

        EmilyWPs.firstWPs = true;

        PlayerCutWPs.secondWPS = true;
        PlayerCutWPs.firstWPs = false;
    }

    public void Anda2()
    {
        JennaWPs.secondWPS = true;
        ChrisWPs.secondWPS = true;
        JamesWPs.secondWPS = true;
        EmilyWPs.secondWPS = true;

        PlayerCutWPs.thirdWPs = true;
    }

    public void Anda3()
    {
        ChrisWPs.thirdWPs = true;
        JamesWPs.thirdWPs = true;
        
    }

    public void Anda4()
    {
        JamesWPs.fouthWPs = true; EmilyWPs.thirdWPs = true;
        //   
    }

    public void Anda5()
    {
        EmilyWPs.fouthWPs = true;
        Kevin.SetActive(true);
        KevinWPs.firstWPs = true;
    }

    public void Anda6()
    {
        KevinWPs.secondWPS = true;
    }

    public void Anda7()
    {
        PlayerCutWPs.fouthWPs = true;
        StartCoroutine(GoHome());
    }

    private IEnumerator GoHome()
    {
        yield return new WaitForSeconds(7);
        nada1 = true;
        Player.SetActive(true);
        CamDea.SetActive(false);
        CamAct.SetActive(true);
        BoundDea.SetActive(true);
        PlayerCut.SetActive(false);
    }

    private IEnumerator PlayerOnHold()
    {
        yield return new WaitForSeconds(0.1f);
        //Player.SetActive(false);
        Player.transform.position = PlayerBackHome;
        Pmov.enabled = false;
    }

}
