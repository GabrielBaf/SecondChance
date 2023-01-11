using UnityEngine;
using System.Collections;

public class GC_Dia5A_NPCs_Casa : MonoBehaviour {

    //Kate
    public GameObject Kate;
    private Waypoint_2WPS KateWPs;
    private NPCFacePlayer_Walker KateFace;
    private TalkNPCWP1 KateTalk;
    //

    private bool SecondWP = false;

	// Use this for initialization
	void Start () {

        KateWPs = Kate.GetComponent<Waypoint_2WPS>();
        KateFace = Kate.GetComponent<NPCFacePlayer_Walker>();
        KateTalk = Kate.GetComponent<TalkNPCWP1>();

    }
	
	// Update is called once per frame
	void Update () {
        //Kate
        
         if (!KateWPs.firstWPs && !SecondWP)
            {
                KateWPs.currentPoint1 = 0;
                StartCoroutine(KateWalkCicle());
            }
        
         if(SecondWP && !KateWPs.secondWPS)
        {
            KateWPs.currentPoint2 = 0;
            StartCoroutine(KateWalkCicle2());
        }

        if (KateTalk.PHere)
        {
            KateFace.enabled = true;
        }
        else
        {
            KateFace.enabled = false;
            KateFace.PlayerInteraction = false;
            KateFace.Diference = 0;
        }

    }

    public IEnumerator KateWalkCicle()
    {
        yield return new WaitForSeconds(3);
        KateWPs.secondWPS = true;
        SecondWP = true;
    }

    public IEnumerator KateWalkCicle2()
    {
        yield return new WaitForSeconds(3);
        SecondWP = false;
        KateWPs.firstWPs = true;
        KateWPs.secondWPS = false;
    }

}
