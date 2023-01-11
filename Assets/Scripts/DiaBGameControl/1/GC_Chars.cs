using UnityEngine;
using System.Collections;

public class GC_Chars : MonoBehaviour {

    public GameObject Steven;
    public GameObject Pamela;
    public GameObject Jenny;
    public GameObject Jenna;
    public GameObject BigB;
    public GameObject Jack;

    //out
    public GameObject KevinOut;
    public GameObject DanOut;

    //hall
    public GameObject Andy;
    public GameObject KevinHall;
    public GameObject DanHall;

    public GameObject MakePeopleWalk;

    private NPCFacePlayer PamelaFace;

    private Waypoint_2WPS StevenWP2;
    private Waypoint_3WPS PamelaWP3;
    private Waypoint_3WPS JennyWP3;
    private Waypoint_3WPS JennaWP3;
    private Waypoint_3WPS BigBWP3;
    private Waypoint_3WPS JackWP3;
    private Waypoint_3WPS AndyWP3;


    private PlayerHere MakeWalkScript;
    private TalkNPCWP1 StevenTalk;


    //out
    private Waypoint_1WPS KevinOutWP;
    private Waypoint_1WPS DanOutWP;

    private NPCFacePlayer KevinOutFace;
    private NPCFacePlayer DanOutFace;

    //hall
    private Waypoint_1WPS KevinHallWP;
    private Waypoint_1WPS DanHallWP;

    private NPCFacePlayer KevinHallFace;
    private NPCFacePlayer DanHallFace;


    // Use this for initialization
    void Start () {

        StevenWP2 = Steven.GetComponent<Waypoint_2WPS>();
        PamelaWP3 = Pamela.GetComponent<Waypoint_3WPS>();
        JennyWP3 = Jenny.GetComponent<Waypoint_3WPS>();
        JennaWP3 = Jenna.GetComponent<Waypoint_3WPS>();
        BigBWP3 = BigB.GetComponent<Waypoint_3WPS>();
        JackWP3 = Jack.GetComponent<Waypoint_3WPS>();
        AndyWP3 = Andy.GetComponent<Waypoint_3WPS>();

        MakeWalkScript = MakePeopleWalk.GetComponent<PlayerHere>();

        PamelaFace = Pamela.GetComponent<NPCFacePlayer>();
        StevenTalk = Steven.GetComponent<TalkNPCWP1>();

        //out
        KevinOutWP = KevinOut.GetComponent<Waypoint_1WPS>();
        DanOutWP = DanOut.GetComponent<Waypoint_1WPS>();
        KevinOutFace = KevinOut.GetComponent<NPCFacePlayer>();
        DanOutFace = DanOut.GetComponent<NPCFacePlayer>();

        //hall
        KevinHallWP = KevinHall.GetComponent<Waypoint_1WPS>();
        DanHallWP = DanHall.GetComponent<Waypoint_1WPS>();
        KevinHallFace = KevinHall.GetComponent<NPCFacePlayer>();
        DanHallFace = DanHall.GetComponent<NPCFacePlayer>();

    }
	
	// Update is called once per frame
	void Update () {

        if (MakeWalkScript.PHere)
        {
            MakeWalkScript.PHere = false;
            MakePeopleWalk.SetActive(false);
            StartCoroutine(HallWalks());
        }

        if(StevenWP2.firstWPs && StevenWP2.secondWPS)
        {
            StevenWP2.firstWPs = false;
        }

	}

    private IEnumerator HallWalks()
    {
        yield return new WaitForSeconds(1.3f);
        JennaWP3.firstWPs = true;
        JennyWP3.firstWPs = true;
        yield return new WaitForSeconds(0.7f);
        BigBWP3.firstWPs = true;
        yield return new WaitForSeconds(0.7f);
        Jack.SetActive(true);
        JackWP3.firstWPs = true;

    }

    public void KevinDanWalkOut()
    {
        KevinOutWP.firstWPs = true;
        KevinOutFace.enabled = false;
        DanOutWP.firstWPs = true;
        DanOutFace.enabled = false;
    }

    public void AndyWalk()
    {
        AndyWP3.firstWPs = true;
    }

    public void KevinDanWalkHall()
    {
        KevinHallWP.firstWPs = true;
        KevinHallFace.enabled = false;
        DanHallWP.firstWPs = true;
        DanHallFace.enabled = false;
    }

    public void GoSteven()
    {
        Steven.SetActive(true);
        StevenWP2.firstWPs = true;
       
        //StartCoroutine(waitforSecondWPSteven());
    }

    public void StevenPamelaPraAula()
    {
        StevenWP2.secondWPS = true;
        PamelaWP3.firstWPs = true;
        PamelaFace.enabled = false;
        StevenTalk.enabled = false;
        //StevenWP2.moveSpeed = 1f;
    }
}
