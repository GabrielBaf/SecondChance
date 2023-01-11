using UnityEngine;
using System.Collections;

public class GC_Day1A_2_NPCS : MonoBehaviour {

    //elizabeth
    public GameObject Eliza;
    private Waypoint_2WPS ElizaWPs;
    private NPCFacePlayer_Walker ElizaFace;
    private TalkNPCWP1 ElizaTalk;

    //Ronald
    public GameObject Ronald;
    private Waypoint_2WPS RonaldWPs;
    private NPCFacePlayer_Walker RonaldFace;
    private TalkNPCWP1 RonaldTalk;

    //Steven
    public GameObject Steven;
    private Waypoint_2WPS StevenWPs;
    private NPCFacePlayer_Walker StevenFace;
    private TalkNPCWP1 StevenTalk;


    private bool ElizaSecondWP = false;
    private bool RonaldSecondWP = false;
    private bool StevenSecondWP = false;

    //

    // Use this for initialization
    void Start () {

        ElizaWPs = Eliza.GetComponent<Waypoint_2WPS>();
        ElizaFace = Eliza.GetComponent<NPCFacePlayer_Walker>();
        ElizaTalk = Eliza.GetComponent<TalkNPCWP1>();

        RonaldWPs = Ronald.GetComponent<Waypoint_2WPS>();
        RonaldFace = Ronald.GetComponent<NPCFacePlayer_Walker>();
        RonaldTalk = Ronald.GetComponent<TalkNPCWP1>();

        StevenWPs = Steven.GetComponent<Waypoint_2WPS>();
        StevenFace = Steven.GetComponent<NPCFacePlayer_Walker>();
        StevenTalk = Steven.GetComponent<TalkNPCWP1>();

    }
	
	// Update is called once per frame
	void Update () {

        //Kate

        if (!ElizaWPs.firstWPs && !ElizaSecondWP)
        {
            ElizaWPs.currentPoint1 = 0;
            StartCoroutine(ElizaWalkCicle());
        }

        if (ElizaSecondWP && !ElizaWPs.secondWPS)
        {
            ElizaWPs.currentPoint2 = 0;
            StartCoroutine(ElizaWalkCicle2());
        }

        if (ElizaTalk.PHere)
        {
            ElizaFace.enabled = true;
        }
        else
        {
            ElizaFace.enabled = false;
            ElizaFace.PlayerInteraction = false;
            ElizaFace.Diference = 0;
        }
        //

        //Ronald

        if (!RonaldWPs.firstWPs && !RonaldSecondWP)
        {
            RonaldWPs.currentPoint1 = 0;
            StartCoroutine(RonaldWalkCicle());
        }

        if (RonaldSecondWP && !RonaldWPs.secondWPS)
        {
            RonaldWPs.currentPoint2 = 0;
            StartCoroutine(RonaldWalkCicle2());
        }

        if (RonaldTalk.PHere)
        {
            RonaldFace.enabled = true;
        }
        else
        {
            RonaldFace.enabled = false;
            RonaldFace.PlayerInteraction = false;
            RonaldFace.Diference = 0;
        }
        //

        //Steven

        if (!StevenWPs.firstWPs && !StevenSecondWP)
        {
            StevenWPs.currentPoint1 = 0;
            StartCoroutine(StevenWalkCicle());
        }

        if (StevenSecondWP && !StevenWPs.secondWPS)
        {
            StevenWPs.currentPoint2 = 0;
            StartCoroutine(StevenWalkCicle2());
        }

        if (StevenTalk.PHere)
        {
            StevenFace.enabled = true;
        }
        else
        {
            StevenFace.enabled = false;
            StevenFace.PlayerInteraction = false;
            StevenFace.Diference = 0;
        }
        //

    }

    public IEnumerator ElizaWalkCicle()
    {
        yield return new WaitForSeconds(3);
        ElizaWPs.secondWPS = true;
        ElizaSecondWP = true;
    }

    public IEnumerator ElizaWalkCicle2()
    {
        yield return new WaitForSeconds(3);
        ElizaSecondWP = false;
        ElizaWPs.firstWPs = true;
        ElizaWPs.secondWPS = false;
    }

    //
    public IEnumerator RonaldWalkCicle()
    {
        yield return new WaitForSeconds(3);
        RonaldWPs.secondWPS = true;
        RonaldSecondWP = true;
    }

    public IEnumerator RonaldWalkCicle2()
    {
        yield return new WaitForSeconds(3);
        RonaldSecondWP = false;
        RonaldWPs.firstWPs = true;
        RonaldWPs.secondWPS = false;
    }

    //
    public IEnumerator StevenWalkCicle()
    {
        yield return new WaitForSeconds(3);
        StevenWPs.secondWPS = true;
        StevenSecondWP = true;
    }

    public IEnumerator StevenWalkCicle2()
    {
        yield return new WaitForSeconds(3);
        StevenSecondWP = false;
        StevenWPs.firstWPs = true;
        StevenWPs.secondWPS = false;
    }

}
